// IDFCurvesBell.js
// Full implementation for Rainfall IDF Bell Method
// - Supports multiple ID naming variants used in views
// - Dynamic input row generation from number of years + start year
// - Validation, summaries, depth & intensity computation (Bell formula placeholder)
// - Populate output tables (supports both `depth_...`/`intensity_...` and `g_i_...`/`g_int_...` ids)
// - Render ECharts graph
// - Export to Excel (SheetJS) and PDF (jsPDF)
// - Session storage (save/restore inputs and outputs)
// - Defensive checks so missing optional libraries or elements don't break
//chnages made 23-2-2026
(function () {
    'use strict';

    // Configuration
    const returnPeriods = [2, 5, 10, 25, 50, 100];
    const durations = [5, 10, 15, 30, 45, 60, 90, 120, 150, 180];

    // State
    const dummy = []
    let rainfallData = [];
    let depthData = {};
    let intensityData = {};
    let chartInstance = null;

    // Helpers to resolve element ids used in different razor variants
    function getByAnyId(...ids) {
        for (const id of ids) {
            if (!id) continue;
            const el = document.getElementById(id);
            if (el) return el;
        }
        return null;
    }

    // Resolve commonly used elements (support both snake_case and camelCase and different chart id)
    const ddlYears = getByAnyId('ddl_years_count', 'ddl_yearsCount');
    const startYearInput = getByAnyId('txt_start_year', 'txt_startYear');
    const rainfallRowsContainer = getByAnyId('rainfall_rows', 'rainfallRows');
    const chartContainer = getByAnyId('chart_idf_bell', 'chart-idfbell');
    const mValueEl = getByAnyId('m_value');
    const nValueEl = getByAnyId('n_value');
    const p3060El = getByAnyId('p_30_60_value');

    // summary error container (inserted dynamically if not present)
    let summaryErrorContainer = document.getElementById('idf_error_summary');

    // Find Next button robustly: by id, by class .btn-action and text 'Next'
    function findNextButton() {
        const byId = getByAnyId('btn_next');
        if (byId) return byId;
        // search for button with class btn-action and text starting with Next
        const candidates = Array.from(document.querySelectorAll('button, input[type="button"], input[type="submit"]'));
        for (const c of candidates) {
            if (c.classList.contains('btn-action') || c.classList.contains('btn')) {
                const text = (c.textContent || c.value || '').trim().toLowerCase();
                if (text === 'next' || text.startsWith('next')) return c;
            }
        }
        return null;
    }

    const nextBtn = findNextButton();

    // Optional buttons for export/feedback (may not be present)
    const exportExcelBtn = getByAnyId('btn_export_excel');
    const exportPdfBtn = getByAnyId('btn_export_pdf');
    const feedbackBtn = getByAnyId('btn_feedback');

    // Attach listeners
    if (ddlYears) ddlYears.addEventListener('change', tryGenerateRows);
    if (startYearInput) startYearInput.addEventListener('change', tryGenerateRows);

    if (nextBtn) nextBtn.addEventListener('click', function (e) {
        e.preventDefault();
        onNext();
    });

    if (exportExcelBtn) exportExcelBtn.addEventListener('click', exportExcel);
    if (exportPdfBtn) exportPdfBtn.addEventListener('click', exportPDF);
    if (feedbackBtn) feedbackBtn.addEventListener('click', captureFeedback);

    // Inject minimal CSS for inline errors, exclamation icon and invalid fields
    (function injectStyles() {
        try {
            const style = document.createElement('style');
            style.type = 'text/css';
            style.innerHTML = `
                .input-error { color: #dc3545; font-size: 0.85rem; margin-top: .25rem; display:block; }
                .field-invalid { border-color: #dc3545 !important; box-shadow: none !important; }
                .subframe-hidden { display: none !important; }
                .input-with-icon { position: relative; }
                .input-error-icon {
                    position: absolute;
                    right: 8px;
                    top: 50%;
                    transform: translateY(-50%);
                    background: #dc3545;
                    color: #fff;
                    width: 18px;
                    height: 18px;
                    line-height: 18px;
                    text-align: center;
                    border-radius: 50%;
                    font-weight: 700;
                    font-size: 12px;
                    cursor: default;
                    box-shadow: 0 0 0 2px rgba(220,53,69,0.12);
                }
            `;
            document.head.appendChild(style);
        } catch (e) { /* ignore */ }
    })();

    // Inline error helpers
    function ensureSummaryContainer() {
        if (summaryErrorContainer) return;
        if (!rainfallRowsContainer) return;
        summaryErrorContainer = document.createElement('div');
        summaryErrorContainer.id = 'idf_error_summary';
        summaryErrorContainer.setAttribute('role', 'alert');
        summaryErrorContainer.style.marginTop = '8px';
        rainfallRowsContainer.parentNode.insertBefore(summaryErrorContainer, rainfallRowsContainer);
    }

    function showSummaryError(msg) {
        ensureSummaryContainer();
        if (!summaryErrorContainer) return;
        summaryErrorContainer.innerHTML = `<div class="input-error">⚠ ${escapeHtml(msg)}</div>`;
    }

    function clearSummaryError() {
        if (summaryErrorContainer) summaryErrorContainer.innerHTML = '';
    }

    function addErrorIcon(inputEl, title) {
        if (!inputEl || !inputEl.parentNode) return;
        const parent = inputEl.parentNode;
        parent.classList.add('input-with-icon');
        let icon = parent.querySelector('.input-error-icon');
        if (!icon) {
            icon = document.createElement('span');
            icon.className = 'input-error-icon';
            parent.appendChild(icon);
        }
        icon.textContent = '!';
        if (title) icon.title = title;
    }

    function removeErrorIcon(inputEl) {
        if (!inputEl || !inputEl.parentNode) return;
        const parent = inputEl.parentNode;
        const icon = parent.querySelector('.input-error-icon');
        if (icon) icon.remove();
        parent.classList.remove('input-with-icon');
    }

    function showFieldError(inputEl, msg) {
        if (!inputEl || !inputEl.parentNode) return;
        inputEl.classList.add('field-invalid');
        addErrorIcon(inputEl, msg);
        let err = inputEl.parentNode.querySelector('.input-error');
        if (!err) {
            err = document.createElement('div');
            err.className = 'input-error';
            inputEl.parentNode.appendChild(err);
        }
        err.innerHTML = `⚠ ${escapeHtml(msg)}`;
    }

    function clearFieldError(inputEl) {
        if (!inputEl || !inputEl.parentNode) return;
        inputEl.classList.remove('field-invalid');
        removeErrorIcon(inputEl);
        const err = inputEl.parentNode.querySelector('.input-error');
        if (err) err.remove();
    }

    function clearAllFieldErrors() {
        if (!rainfallRowsContainer) return;
        const inputs = rainfallRowsContainer.querySelectorAll('input');
        inputs.forEach(i => clearFieldError(i));
        clearSummaryError();
    }

    function escapeHtml(s) {
        if (!s) return '';
        return s.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    // Hide output sub-frame initially. Show sub-frames sequentially (one after the other)
    const subFrames = Array.from(document.querySelectorAll('sub-frame'));
    // Find index of output results frame by title text if possible
    let outputSubFrame = null;
    let outputSubFrameIndex = -1;
    if (subFrames && subFrames.length > 0) {
        for (let idx = 0; idx < subFrames.length; idx++) {
            const sf = subFrames[idx];
            try {
                if (sf.getAttribute('title') && sf.getAttribute('title').toLowerCase().includes('output')) {
                    outputSubFrame = sf;
                    outputSubFrameIndex = idx;
                    break;
                }
                if (sf.textContent && sf.textContent.toLowerCase().includes('output results')) {
                    outputSubFrame = sf; outputSubFrameIndex = idx; break;
                }
            } catch (e) { /* ignore */ }
        }
        // fallback: assume second sub-frame is output
        if (!outputSubFrame && subFrames.length >= 2) {
            outputSubFrame = subFrames[1];
            outputSubFrameIndex = 1;
        }

        if (outputSubFrame) {
            // hide initially
            outputSubFrame.classList.add('subframe-hidden');
        }
    }

    // Checks that all required inputs in sub-frames before output are filled and valid
    function isPreviousSubFramesComplete() {
        if (!outputSubFrame || outputSubFrameIndex <= 0) return true;
        for (let i = 0; i < outputSubFrameIndex; i++) {
            const sf = subFrames[i];
            if (!sf) continue;
            // find required inputs/selects inside this subframe
            const requiredEls = sf.querySelectorAll('input[required], select[required], textarea[required]');
            for (const el of requiredEls) {
                const val = (el.value || '').toString().trim();
                if (val === '') {
                    // mark visually
                    showFieldError(el, 'This field is required');
                    return false;
                }
                // also ensure no field-invalid exists
                if (el.classList.contains('field-invalid')) return false;
            }
        }
        return true;
    }

    // Reveal output sub-frame after validation; used by Next and other output buttons
    function revealOutputSubFrame() {
        clearAllFieldErrors();
        collectData();
        if (!validateData()) return false;
        calculateSummaries();
        if (!validateSummaries()) return false;
        if (!isPreviousSubFramesComplete()) {
            showSummaryError('Please complete all required fields before proceeding.');
            return false;
        }

        // compute and display outputs
        computeDepths();
        computeIntensities();
        populateDepthTable();
        populateIntensityTable();
        renderChart();
        handleSession();

        if (outputSubFrame) {
            outputSubFrame.classList.remove('subframe-hidden');
            try { outputSubFrame.scrollIntoView({ behavior: 'smooth', block: 'start' }); } catch (e) { }
        }
        return true;
    }

    // wire up any output buttons (id 'outputBtn' or text containing 'output') to reveal output
    function findOutputButtons() {
        const result = [];
        const byId = document.getElementById('outputBtn');
        if (byId) result.push(byId);
        const candidates = Array.from(document.querySelectorAll('button, a, input[type="button"], input[type="submit"]'));
        for (const c of candidates) {
            const text = (c.textContent || c.value || '').trim().toLowerCase();
            if (text && (text === 'output' || text.startsWith('output') || text.includes('output report') || text.includes('output report'))) {
                if (!result.includes(c)) result.push(c);
            }
        }
        return result;
    }

    const outputButtons = findOutputButtons();
    outputButtons.forEach(b => {
        try {
            b.addEventListener('click', function (e) {
                e.preventDefault();
                revealOutputSubFrame();
            });
        } catch (e) { }
    });

    // Try to generate rows only when both inputs available
    function tryGenerateRows() {
        const countVal = ddlYears ? ddlYears.value : '';
        const startVal = startYearInput ? startYearInput.value : '';
        if (!countVal || !startVal) return;
        generateRows();
    }

    function generateRows() {
        if (!ddlYears || !rainfallRowsContainer || !startYearInput) return;
        const count = parseInt(ddlYears.value, 10);
        const startYear = parseInt(startYearInput.value, 10);
        if (!Number.isInteger(count) || count <= 0) return;
        if (!Number.isInteger(startYear)) return;

        // Clear previous
        rainfallRowsContainer.innerHTML = '';
        rainfallData = [];
        clearOutputs();

        for (let i = 0; i < count; i++) {
            const year = startYear + i;
            const row = document.createElement('div');
            row.className = 'row rainfall-row';
            row.innerHTML = `
                <div class="col-md-3 tce-grid-border">
                    <input type="text" class="form-control" value="${year}" readonly id="year_${i}" />
                </div>
                <div class="col-md-3 tce-grid-border">
                    <input type="number" step="any" class="form-control" placeholder="Annual Rainfall" id="ar_${i}" required />
                </div>
                <div class="col-md-3 tce-grid-border">
                    <input type="number" step="1" class="form-control" placeholder="Rainy Days" id="rd_${i}" required />
                </div>
                <div class="col-md-3 tce-grid-border">
                    <input type="number" step="any" class="form-control" placeholder="Max 24-hr Rain" id="maxrain_${i}" required />
                </div>
            `;
            rainfallRowsContainer.appendChild(row);
        }

        // ensure each input parent can host an icon
        const inputs = rainfallRowsContainer.querySelectorAll('input');
        inputs.forEach(inp => {
            try { inp.parentNode.classList.add('input-with-icon'); } catch (e) { }
            // clear any previous icon
            removeErrorIcon(inp);
        });

        // focus first input
        const first = document.getElementById('ar_0');
        if (first) first.focus();
    }

    function onNext() {
        // Use revealOutputSubFrame so output only shows via Next button
        revealOutputSubFrame();
    }

    function collectData() {
        rainfallData = [];
        // determine count from generated inputs if available
        let count = 0;
        if (ddlYears && ddlYears.value) count = parseInt(ddlYears.value, 10);
        else {
            // fallback: count inputs by scanning for year_0
            while (document.getElementById(`year_${count}`)) count++;
        }
        if (!Number.isInteger(count) || count <= 0) return;

        for (let i = 0; i < count; i++) {
            const yearEl = document.getElementById(`year_${i}`);
            const arEl = document.getElementById(`ar_${i}`);
            const rdEl = document.getElementById(`rd_${i}`);
            const maxRainEl = document.getElementById(`maxrain_${i}`);

            rainfallData.push({
                year: yearEl ? parseInt(yearEl.value, 10) || (new Date().getFullYear() + i) : (new Date().getFullYear() + i),
                annualRainfall: arEl ? parseFloat(arEl.value) || 0 : 0,
                rainyDays: rdEl ? parseInt(rdEl.value, 10) || 0 : 0,
                maxRain: maxRainEl ? parseFloat(maxRainEl.value) || 0 : 0
            });
        }
    }

    function validateData() {
        if (!rainfallData || rainfallData.length === 0) {
            showSummaryError('No rainfall input rows found. Enter number of years and start year, then fill table.');
            return false;
        }
        let ok = true;
        let firstInvalidEl = null;
        rainfallData.forEach((r, i) => {
            const arEl = document.getElementById(`ar_${i}`);
            const rdEl = document.getElementById(`rd_${i}`);
            const maxRainEl = document.getElementById(`maxrain_${i}`);

            // clear previous for each
            clearFieldError(arEl);
            clearFieldError(rdEl);
            clearFieldError(maxRainEl);

            // check required fields: annual rainfall, rainy days, maxrain
            if (arEl && (arEl.value === null || (arEl.value || '').toString().trim() === '')) {
                showFieldError(arEl, 'Annual Rainfall is required');
                ok = false;
                if (!firstInvalidEl) firstInvalidEl = arEl;
            }

            if (!Number.isInteger(r.rainyDays) || r.rainyDays < 1 || r.rainyDays > 80) {
                showFieldError(rdEl, 'Rainy Days must be an integer between 1 and 80');
                ok = false;
                if (!firstInvalidEl) firstInvalidEl = rdEl;
            }
            if (isNaN(r.maxRain) || r.maxRain <= 0) {
                showFieldError(maxRainEl, 'Max 24-hr Rain must be a positive number');
                ok = false;
                if (!firstInvalidEl) firstInvalidEl = maxRainEl;
            }
            if (r.maxRain > 115) {
                showFieldError(maxRainEl, 'Max 24-hr Rain must be less than 115 mm');
                ok = false;
                if (!firstInvalidEl) firstInvalidEl = maxRainEl;
            }
        });

        if (!ok) {
            showSummaryError('Please correct highlighted fields.');
            if (firstInvalidEl) try { firstInvalidEl.focus(); } catch (e) { }
        } else {
            clearSummaryError();
        }

        return ok;
    }

    function calculateSummaries() {
        if (!rainfallData || rainfallData.length === 0) {
            setSummaryValues(null, null, null);
            return;
        }
        const meanMaxRain = rainfallData.reduce((s, r) => s + (r.maxRain || 0), 0) / rainfallData.length;
        const meanRainyDays = rainfallData.reduce((s, r) => s + (r.rainyDays || 0), 0) / rainfallData.length;
        const P3060 = meanMaxRain * (30 / 60); // placeholder; keep existing formula
        setSummaryValues(meanMaxRain, meanRainyDays, P3060);
    }

    function setSummaryValues(M, N, P3060) {
        if (mValueEl) mValueEl.textContent = (M !== null && !isNaN(M)) ? M.toFixed(2) : '';
        if (nValueEl) nValueEl.textContent = (N !== null && !isNaN(N)) ? N.toFixed(2) : '';
        if (p3060El) p3060El.textContent = (P3060 !== null && !isNaN(P3060)) ? P3060.toFixed(2) : '';
    }

    function validateSummaries() {
        const M = mValueEl ? parseFloat(mValueEl.textContent) : NaN;
        const N = nValueEl ? parseFloat(nValueEl.textContent) : NaN;
        if (isNaN(M) || isNaN(N)) {
            showSummaryError('Summary values missing. Ensure inputs are valid and click Next.');
            return false;
        }
        if (M > 115) { showSummaryError('Validation Error: M must be less than 115 mm'); return false; }
        if (N < 1 || N > 80) { showSummaryError('Validation Error: N must be between 1 and 80'); return false; }
        clearSummaryError();
        return true;
    }

    // Bell formula placeholder - keep as previous
    function bellFormula(M, N, T, d) {
        return M * Math.sqrt(d / 60) * Math.log(T) * (N / 50);
    }

    function computeDepths() {
        depthData = {};
        const M = mValueEl ? parseFloat(mValueEl.textContent) || 0 : 0;
        const N = nValueEl ? parseFloat(nValueEl.textContent) || 0 : 0;
        returnPeriods.forEach(T => {
            depthData[T] = {};
            durations.forEach(d => {
                const val = bellFormula(M, N, T, d);
                depthData[T][d] = isFinite(val) ? val : 0;
            });
        });
    }

    function computeIntensities() {
        intensityData = {};
        returnPeriods.forEach(T => {
            intensityData[T] = {};
            durations.forEach(d => {
                const depth = depthData[T] && typeof depthData[T][d] !== 'undefined' ? depthData[T][d] : 0;
                const value = d > 0 ? (depth / (d / 60)) : 0;
                intensityData[T][d] = isFinite(value) ? value : 0;
            });
        });
    }

    // Populate supports both id formats used in different views
    function populateDepthTable() {
        returnPeriods.forEach(T => {
            durations.forEach(d => {
                const id1 = `depth_${T}_${d}`; // original pattern
                const id2 = `g_i_${T}_${d}`;   // current view
                const val = depthData[T] && typeof depthData[T][d] !== 'undefined' ? Number(depthData[T][d]).toFixed(2) : '0.00';
                const el1 = document.getElementById(id1);
                const el2 = document.getElementById(id2);
                if (el1) el1.textContent = val;
                if (el2) el2.textContent = val;
            });
        });
    }

    function populateIntensityTable() {
        returnPeriods.forEach(T => {
            durations.forEach(d => {
                const id1 = `intensity_${T}_${d}`;
                const id2 = `g_int_${T}_${d}`;
                const val = intensityData[T] && typeof intensityData[T][d] !== 'undefined' ? Number(intensityData[T][d]).toFixed(2) : '0.00';
                const el1 = document.getElementById(id1);
                const el2 = document.getElementById(id2);
                if (el1) el1.textContent = val;
                if (el2) el2.textContent = val;
            });
        });
    }

    function renderChart() {
        if (!chartContainer) return;
        if (typeof echarts === 'undefined') {
            console.warn('echarts library not found, skipping chart');
            return;
        }

        try { if (chartInstance) { chartInstance.dispose(); chartInstance = null; } } catch (e) { /* ignore */ }
        chartInstance = echarts.init(chartContainer);

        const series = returnPeriods.map(T => ({
            name: `T=${T} yrs`,
            type: 'line',
            data: durations.map(d => {
                const v = intensityData[T] && typeof intensityData[T][d] !== 'undefined' ? intensityData[T][d] : 0;
                return Number(v);
            }),
            smooth: true
        }));

        const option = {
            title: { text: 'IDF Curve using Bell Method' },
            tooltip: { trigger: 'axis' },
            legend: { data: series.map(s => s.name) },
            xAxis: { type: 'category', data: durations.map(String), name: 'Duration (minutes)' },
            yAxis: { type: 'value', name: 'Rainfall Intensity (mm/hr)' },
            series
        };

        chartInstance.setOption(option);
    }

    function clearOutputs() {
        setSummaryValues(null, null, null);
        // reset tables to 'Calculated'
        returnPeriods.forEach(T => {
            durations.forEach(d => {
                const ids = [`depth_${T}_${d}`, `g_i_${T}_${d}`, `intensity_${T}_${d}`, `g_int_${T}_${d}`];
                ids.forEach(id => {
                    const el = document.getElementById(id);
                    if (el) {
                        if (id.startsWith('depth') || id.startsWith('g_i')) el.textContent = 'Calculated';
                        else el.textContent = 'Calculated';
                    }
                });
            });
        });
        depthData = {};
        intensityData = {};
        if (chartInstance) {
            try { chartInstance.dispose(); } catch (e) { /* ignore */ }
            chartInstance = null;
            if (chartContainer) chartContainer.innerHTML = '';
        }
        clearAllFieldErrors();
    }

    function exportExcel() {
        if (typeof XLSX === 'undefined') {
            alert('SheetJS (XLSX) library not found. Cannot export to Excel.');
            return;
        }
        const wb = XLSX.utils.book_new();
        const data = [['Return Period', 'Duration (min)', 'Depth (mm)', 'Intensity (mm/hr)']];
        returnPeriods.forEach(T => durations.forEach(d => {
            const depth = depthData[T] && typeof depthData[T][d] !== 'undefined' ? Number(depthData[T][d]).toFixed(2) : '';
            const intensity = intensityData[T] && typeof intensityData[T][d] !== 'undefined' ? Number(intensityData[T][d]).toFixed(2) : '';
            data.push([T, d, depth, intensity]);
        }));
        const ws = XLSX.utils.aoa_to_sheet(data);
        XLSX.utils.book_append_sheet(wb, ws, 'IDF Bell');
        XLSX.writeFile(wb, 'IDF_Bell.xlsx');
    }

    function exportPDF() {
        if (typeof jsPDF === 'undefined') {
            alert('jsPDF library not found. Cannot export to PDF.');
            return;
        }
        const doc = new jsPDF();
        doc.setFontSize(14);
        doc.text('IDF Curve using Bell Method', 10, 10);
        let y = 20;
        doc.setFontSize(10);
        doc.text('Return Period | Duration | Depth(mm) | Intensity(mm/hr)', 10, y);
        y += 8;
        returnPeriods.forEach(T => durations.forEach(d => {
            const depth = depthData[T] && typeof depthData[T][d] !== 'undefined' ? Number(depthData[T][d]).toFixed(2) : '';
            const intensity = intensityData[T] && typeof intensityData[T][d] !== 'undefined' ? Number(intensityData[T][d]).toFixed(2) : '';
            const line = `${T} yrs | ${d} min | ${depth} | ${intensity}`;
            doc.text(line, 10, y);
            y += 6;
            if (y > 280) { doc.addPage(); y = 20; }
        }));
        doc.save('IDF_Bell.pdf');
    }

    function captureFeedback() {
        const opts = document.querySelectorAll("input[name='feedback']");
        let selected = null;
        opts.forEach(o => { if (o.checked) selected = o.value; });
        if (selected) { alert('Thanks for feedback: ' + selected); }
        else alert('Please select a feedback option.');
    }

    function handleSession() {
        try {
            sessionStorage.setItem('idf_rainfallData', JSON.stringify(rainfallData));
            sessionStorage.setItem('idf_depthData', JSON.stringify(depthData));
            sessionStorage.setItem('idf_intensityData', JSON.stringify(intensityData));
        } catch (e) { /* ignore */ }
    }

    function restoreSession() {
        try {
            const r = sessionStorage.getItem('idf_rainfallData');
            if (r) rainfallData = JSON.parse(r);
            const d = sessionStorage.getItem('idf_depthData');
            if (d) depthData = JSON.parse(d);
            const it = sessionStorage.getItem('idf_intensityData');
            if (it) intensityData = JSON.parse(it);
        } catch (e) { /* ignore */ }
    }

    // Initialize: restore and populate if possible
    restoreSession();
    if (Object.keys(depthData).length > 0) {
        populateDepthTable();
        populateIntensityTable();
        renderChart();
    }

    // If page already has years and start, generate rows
    if (ddlYears && ddlYears.value && startYearInput && startYearInput.value) {
        generateRows();
    }

    // Expose for debugging if needed
    window.IDFCurvesBell = {
        generateRows,
        collectData,
        calculateSummaries,
        computeDepths,
        computeIntensities,
        populateDepthTable,
        populateIntensityTable,
        renderChart,
        clearOutputs,
        // expose reveal function so other scripts can trigger output reveal
        revealOutputSubFrame
    };

})();
function outPutPanel() {
    // Preserve existing behavior (show project details) but ensure output sub-frame is revealed
    try {
        if (window.IDFCurvesBell && typeof window.IDFCurvesBell.revealOutputSubFrame === 'function') {
            window.IDFCurvesBell.revealOutputSubFrame();
        } else {
            $('#projectDetails').show('easy');
        }
    } catch (e) {
        $('#projectDetails').show('easy');
    }
}