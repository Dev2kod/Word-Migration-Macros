const ddlm = document.getElementById("ddlm");
const paneld1 = document.getElementById("paneld1");
const paneld2 = document.getElementById("paneld2");
const paneld3 = document.getElementById("paneld3");
const paneld4 = document.getElementById("paneld4");
const paneld5 = document.getElementById("paneld5");
const paneld6 = document.getElementById("paneld6");

ddlm.addEventListener("change", function () {
    if (this.value === "DI") {
        paneld1.classList.remove("d-none");

        paneld2.classList.add("d-none");
        paneld3.classList.add("d-none");
        paneld4.classList.add("d-none");
        paneld5.classList.add("d-none");
        paneld6.classList.add("d-none");
        document.getElementById("TextBox23").value = 130;
        document.getElementById("TextBox39").value = document.getElementById("ddld1").value;

    }
    else if (this.value === "CI") {
        paneld1.classList.add("d-none");
        paneld3.classList.add("d-none");
        paneld4.classList.add("d-none");
        paneld5.classList.add("d-none");
        paneld6.classList.add("d-none");

        paneld2.classList.remove("d-none");
        document.getElementById("TextBox23").value = 130;
        document.getElementById("TextBox39").value = document.getElementById("ddld2").value;
    }
    else if (this.value === "HDPE") {
        paneld1.classList.add("d-none");
        paneld2.classList.add("d-none");
        paneld4.classList.add("d-none");
        paneld5.classList.add("d-none");
        paneld6.classList.add("d-none");

        paneld3.classList.remove("d-none");
        document.getElementById("TextBox23").value = 140;
        document.getElementById("TextBox39").value = document.getElementById("ddld3").value;
    }
    else if (this.value === "MS") {
        paneld1.classList.add("d-none");
        paneld2.classList.add("d-none");
        paneld3.classList.add("d-none");
        paneld5.classList.add("d-none");
        paneld6.classList.add("d-none");

        paneld4.classList.remove("d-none")
        document.getElementById("TextBox23").value = 130;
        document.getElementById("TextBox39").value = document.getElementById("ddld4").value;
    }
    else if (this.value === "GRP") {
        paneld1.classList.add("d-none");
        paneld2.classList.add("d-none");
        paneld3.classList.add("d-none");
        paneld4.classList.add("d-none");
        paneld6.classList.add("d-none");

        paneld5.classList.remove("d-none")
        document.getElementById("TextBox23").value = 140;
        document.getElementById("TextBox39").value = document.getElementById("ddld5").value;
    }
    else if (this.value === "PSC") {
        paneld1.classList.add("d-none");
        paneld2.classList.add("d-none");
        paneld3.classList.add("d-none");
        paneld4.classList.add("d-none");
        paneld5.classList.add("d-none");

        paneld6.classList.remove("d-none")
        document.getElementById("TextBox23").value = 130;
        document.getElementById("TextBox39").value = document.getElementById("ddld6").value;

    }
})


/*Helper for button_calc_click */
function formatNumber(num) {
    if (num === undefined || num === null) return "";
    if (typeof num !== "number" || Number.isNaN(num)) return "";

    // Count digits in the integer part (ignore sign)
    const intLen = Math.trunc(Math.abs(num)).toString().length;

    if (intLen >= 15) {
        // Scientific notation with 13 fractional digits to match your sample:
        // 9044738681142204 -> 9.0447386811422E+15
        return num.toExponential(13).replace('e', 'E');
    } else {
        // Regular formatting with 2 decimals:
        // 803810.9642387717 -> 803810.96
        return num.toFixed(2);
    }
}


let flow1;
let flow2;
let phour;
let tw;
let id;
let k;
let E;

function button_calc_click() {

    if (!ValidateData()) {
        return;
    }

    document.getElementById("button_calc").disabled = true;
    document.getElementById("refresh_button").disabled = false;
    document.getElementById("result_button").disabled = false;


    flow1 = parseFloat(document.getElementById("TextBox1").value);
    flow2 = parseFloat(document.getElementById("TextBox2").value);
    phour = parseFloat(document.getElementById("TextBox3").value);
    l_pmain = parseFloat(document.getElementById("TextBox4").value);
    dis_elv = parseFloat(document.getElementById("TextBox5").value);
    low_level = parseFloat(document.getElementById("TextBox6").value);
    res_head = parseFloat(document.getElementById("TextBox7").value);
    stn_loss = parseFloat(document.getElementById("TextBox8").value);
    pow_tariff = parseFloat(document.getElementById("TextBox9").value);
    esc_pow_tariff = parseFloat(document.getElementById("TextBox10").value);
    ann_rate = parseFloat(document.getElementById("TextBox11").value);
    esc_ann_rate = parseFloat(document.getElementById("TextBox12").value);
    n = parseFloat(document.getElementById("TextBox13").value);
    l_pipe = parseFloat(document.getElementById("TextBox14").value);
    l_pump = parseFloat(document.getElementById("TextBox15").value);

    pump_eff = parseFloat(document.getElementById("TextBox18").value);
    motor_eff = parseFloat(document.getElementById("TextBox19").value);
    cost_pump = parseFloat(document.getElementById("TextBox20").value);
    omfac_pump = parseFloat(document.getElementById("TextBox21").value);
    omfac_pipe = parseFloat(document.getElementById("TextBox22").value);
    standby = parseFloat(document.getElementById("txt_proposedstand").value);

    tw = parseFloat(document.getElementById("txt_tw").value);
    id = parseFloat(document.getElementById("txt_di").value);
    k = parseFloat(document.getElementById("txt_k").value);
    E = parseFloat(document.getElementById("txt_E").value);

    TextBox38 = parseFloat(document.getElementById("TextBox38").value);
    TextBox23 = parseFloat(document.getElementById("TextBox23").value);

    flowphr1 = flow1 * 1000 / phour;
    flowphr2 = flow2 * 1000 / phour;
    flowps1 = flowphr1 / 3600;
    flowps2 = flowphr2 / 3600;

    vel_act = flowps1 / (0.7854 * Math.pow((id / 1000), 2));
    vel_act2 = flowps2 / (0.7854 * Math.pow((id / 1000), 2));
    cost_pipeline = TextBox38 * l_pmain / 100000;
    loss_friction = Math.pow((flowphr1 / (1.292 * 0.00001 * TextBox23 * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;
    loss_friction2 = Math.pow((flowphr2 / (1.292 * 0.00001 * TextBox23 * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;
    loss_minor = 0.07 * loss_friction;
    loss_minor2 = 0.07 * loss_friction2;
    st_head = dis_elv - low_level;
    pump_head = loss_friction + loss_minor + st_head + res_head + stn_loss;
    pump_head2 = loss_friction2 + loss_minor2 + st_head + res_head + stn_loss;
    w_hammer1 = (vel_act / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
    w_hammer2 = (vel_act2 / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
    pump_kw = (flowphr1 * pump_head) / (367.25 * pump_eff / 100 * motor_eff / 100);
    pump_kw2 = (flowphr2 * pump_head2) / (367.25 * pump_eff / 100 * motor_eff / 100);


    cost_pumpset = pump_kw * (1 + (standby / 100)) * cost_pump / 100000;
    cost_pumpset2 = pump_kw2 * (1 + (standby / 100)) * cost_pump / 100000;
    pow_py = pump_kw * phour * 365;
    pow_py2 = pump_kw2 * phour * 365;
    pow_costfy = pow_py * pow_tariff / 100000;
    pow_costfy2 = pow_py2 * pow_tariff / 100000;


    cost_pumpset_15y = cost_pumpset2 * Math.pow(1 + (esc_ann_rate / 100), 15);

    om_pumpset_py = omfac_pump / 100 * cost_pumpset;
    om_pumpset_py2 = omfac_pump / 100 * cost_pumpset2;
    om_pipe_py = omfac_pipe / 100 * cost_pipeline;
    Xf = (1 + (esc_ann_rate / 100)) / (1 + (ann_rate / 100));

    pw_replace = cost_pumpset_15y / Math.pow((1 + (ann_rate / 100)), l_pump);


    pw_pow_cost = pow_costfy * Xf * (1 - Math.pow(Xf, n)) / (1 - Xf);
    pw_pow_cost2 = pow_costfy2 * Xf * (1 - Math.pow(Xf, n)) / (1 - Xf);

    total_pw_pow_cost = pw_pow_cost + pw_pow_cost2;

    pw_pipeline_om = om_pipe_py * Xf * (1 - Math.pow(Xf, l_pipe)) / (1 - Xf);
    pw_pumpset_om = om_pumpset_py * Xf * (1 - Math.pow(Xf, l_pump)) / (1 - Xf);
    pw_pumpset_om2 = om_pumpset_py2 * Xf * (1 - Math.pow(Xf, l_pump)) / (1 - Xf);


    total_pw1 = cost_pumpset + pw_pow_cost + pw_pumpset_om;
    total_pw2 = cost_pumpset2 + pw_pow_cost2 + pw_pumpset_om2;
    total_pw = total_pw1 + total_pw2 + (pw_pipeline_om + cost_pipeline);





    // applying the function
    document.getElementById("txtact_vel").value = formatNumber(vel_act);
    document.getElementById("txtact_vel2").value = formatNumber(vel_act2);
    document.getElementById("txtunitrate").value = TextBox38;

    document.getElementById("TextBox78").value = formatNumber(loss_friction);
    document.getElementById("TextBox98").value = formatNumber(loss_friction2);

    document.getElementById("txtpump_kw").value = formatNumber(pump_kw);
    document.getElementById("txtpump_kw2").value = formatNumber(pump_kw2);

    document.getElementById("txtcost_pumpset").value = formatNumber(cost_pumpset);
    document.getElementById("txtpw_replace").value = formatNumber(cost_pumpset2);

    document.getElementById("txtXf").value = formatNumber(Xf);
    document.getElementById("txtpow_py").value = formatNumber(pow_py);
    document.getElementById("txtpow_py2").value = formatNumber(pow_py2);

    document.getElementById("txtpw_pipeline_om").value = formatNumber(pw_pipeline_om);
    document.getElementById("txtpw_pumpset_om").value = formatNumber(pw_pumpset_om);
    document.getElementById("txtpw_pumpset_om2").value = formatNumber(pw_pumpset_om2);

    document.getElementById("txtpw_pow_cost").value = formatNumber(pw_pow_cost);
    document.getElementById("txtpw_pow_cost2").value = formatNumber(pw_pow_cost2);

    document.getElementById("TextBox99").value = formatNumber(total_pw_pow_cost);

    document.getElementById("txttotal_pw1").value = formatNumber(total_pw1);
    document.getElementById("txttotal_pw2").value = formatNumber(total_pw2);
    document.getElementById("txttotal_pw").value = formatNumber(total_pw);

    document.getElementById("txtpw_pipe").value = formatNumber(cost_pipeline);
    document.getElementById("txtpw_pumpset").value = formatNumber(cost_pumpset);
    document.getElementById("txtpw_pumpset2").value = formatNumber(cost_pumpset2);

}



const dtDatas = [];
const dtDatas1 = [];
const dtDatas2 = [];


window.dtDatas = dtDatas;
window.dtDatas1 = dtDatas1;
window.dtDatas2 = dtDatas2;

/*Helpers for addResult */

const byId = id => document.getElementById(id) || null;

function getValue(id) {
    const el = byId(id);
    if (!el) return '';
    if (el.tagName === 'SELECT' || el.tagName === 'INPUT' || el.tagName === 'TEXTAREA') {
        return (el.value ?? '').trim();
    }
    return (el.textContent ?? '').trim();
}


// Render a table from an array of objects
function renderTable(tableId, rows) {
    const table = byId(tableId);
    if (!table) return;

    if (!rows || rows.length === 0) {
        table.innerHTML = '<tr><td><em>No data</em></td></tr>';
        return;
    }

    // Build header from object keys of the first row
    const cols = Object.keys(rows[0]);


    let thead = '<thead class="bg-secondary text-white" ><tr  >';
    for (const col of cols) {
        thead += `<th>${col}</th>`;
    }
    thead += '</tr></thead>';

    let tbody = '<tbody>';
    for (const row of rows) {
        tbody += '<tr >';
        for (const col of cols) {
            tbody += `<td>${row[col] ?? ''}</td>`;
        }
        tbody += '</tr>';
    }
    tbody += '</tbody>';


    table.innerHTML = thead + tbody;
}



// highlight the table latest row 
$("#result_button").click(function () {
    $("#gv3 tbody tr").removeClass("bg-warning");
    $("#gv3 tbody tr:last").addClass("bg-warning");
    $("#gv2 tbody tr").removeClass("bg-warning");
    $("#gv2 tbody tr:last").addClass("bg-warning");
    $("#gv1 tbody tr").removeClass("bg-warning");
    $("#gv1 tbody tr:last").addClass("bg-warning");
});



function addResult() {
    try {
        $("#result_button").prop("disabled", true);
        $("#continue_button").prop("disabled", false);

        $("#three_tables").removeClass("d-none");

        
        const drNewRow = {
            "Diameter": getValue("TextBox39"),
            "Inner Diameter": getValue("txt_di"),
            "Actual velocity_StageI": getValue("txtact_vel"),
            "Pipe friction loss_StageI": getValue("TextBox78"),
            "Total head of pump_StageI": getValue("txtpump_head"),
            "Pump kW_StageI": getValue("txtpump_kw"),
            "Water hammer head_StageI": getValue("txt_waterhammer_1"),
            "Capital cost of pumpsets_StageI": getValue("txtcost_pumpset"),
            "X factor": getValue("txtXf"),
            "Power required in one year_StageI": getValue("txtpow_py"),
            "Net present value of Capital Cost for Pipeline_StageI": getValue("txtpw_pipe"),
            "Net Present Value of O & M cost for Pipeline_StageI": getValue("txtpw_pipeline_om"),
            "Net present value of Capital Cost for Pumpsets_StageI": getValue("txtpw_pumpset"),
            "Net Present Value of O & M cost for Pumpsets_StageI": getValue("txtpw_pumpset_om"),
            "Net Present value of Power cost_StageI": getValue("txtpw_pow_cost"),
            "Total Net Present Value_StageI": getValue("txttotal_pw1")
        };
        dtDatas.push(drNewRow);

     
        const drNewRow1 = {
            "Flow for stage 1": getValue("TextBox1"),
            "Flow for stage 2": getValue("TextBox2"),
            "Pumping hours": getValue("TextBox3"),
            "Length of Pumping Main": getValue("TextBox4"),
            "Discharge Point Elevation": getValue("TextBox5"),
            "Low water level at source": getValue("TextBox6"),
            "Residual Head": getValue("TextBox7"),
            "Station Losses": getValue("TextBox8"),
            "Power Tariff": getValue("TextBox9"),
            "Escalation of Power Tariff": getValue("TextBox10"),
            "Escalated Rate": getValue("TextBox12"),
            "Annual Intrest Rate": getValue("TextBox11"),
            "Material Considered": getValue("ddlm"),
            "Nos of year to be considered (Design Period)": getValue("TextBox13"),
            "Life of Pipeline": getValue("TextBox14"),
            "Life of the pumpsets": getValue("TextBox15"),
            "Pump Efficiency": getValue("TextBox18"),
            "Motor Efficiency": getValue("TextBox19"),
            "Cost of Pumpsets": getValue("TextBox20"),
            "O & M cost factor for pumpset per year": getValue("TextBox21"),
            "O & M cost factor for pipeline per year": getValue("TextBox22"),
            "Hazen Williams Coefficient": getValue("TextBox23"),
            "Material Unit Rate": getValue("TextBox38"),
            "Wall Thickness of Pipe": getValue("txt_tw"),
            "Bulk Modulus of Water": getValue("txt_k"),
            "Modulus of Elasticity of Pipe Material": getValue("txt_E"),
            "Allowable Withstanding Pressure of Selected Pipe": getValue("txt_pr1"),
            "Proposed Standby": getValue("txt_proposedstand")
        };
        dtDatas1.push(drNewRow1);

      
        const drNewRow2 = {
            "Actual velocity_StageII": getValue("txtact_vel2"),
            "Pipe friction loss_StageII": getValue("TextBox98"),
            "Total head of pump_StageII": getValue("txtpump_head2"),
            "Pump kW_StageII": getValue("txtpump_kw2"),
            "Water hammer head_StageII": getValue("txt_waterhammer_2"),
            "Capital cost of pumpsets_StageII": getValue("txtpw_replace"),
            "Power required in one year_StageII": getValue("txtpow_py2"),
            "Net present value of Capital Cost for Pumpsets_StageII": getValue("txtpw_pumpset2"),
            "Net Present value of Power cost_StageII": getValue("txtpw_pow_cost2"),
            "Net Present Value of O & M cost for Pumpsets_StageII": getValue("txtpw_pumpset_om2"),
            "Total Net Present Value_StageII": getValue("txttotal_pw2"),
            "Total Net Present Value": getValue("txttotal_pw")
        };
        dtDatas2.push(drNewRow2);

        
        renderTable('gv1', dtDatas);
        renderTable('gv2', dtDatas1);
        renderTable('gv3', dtDatas2);

    } catch (err) {
        console.error(err);
        alert("Something went wrong while adding rows. Check console for details.");
    }
}


function toNum(v) {
    const n = Number(String(v).replace(/,/g, '').trim());
    return Number.isFinite(n) ? n : NaN;
}

function optimumDiameter() {



    if (!Array.isArray(window.dtDatas) || !Array.isArray(window.dtDatas2)) {
        console.error('dtDatas/dtDatas2 not found. Make sure they are defined and filled.');
        return;
    }

    const n = dtDatas.length;
    if (n === 0) {
        alert('No rows available to compute optimal diameter.');
        return;
    }

    if (dtDatas2.length !== dtDatas.length) {
        console.warn('Row count mismatch: dtDatas vs dtDatas2. Will use the smaller length.');
    }



    const len = Math.min(dtDatas.length, dtDatas2.length);

    const outEl = byId('txtdia_opt');  // opt daimeter
    const dbgZ = byId('TextBox54');
    const dbgD = byId('TextBox55');
    const dbg50 = byId('TextBox50');
    const dbg51 = byId('TextBox51');
    const dbg52 = byId('TextBox52');
    const dbg53 = byId('TextBox53');


    $("#optimum_diameter_button").prop("disabled", true);
    $("#detailed_results").prop("disabled", false);


    const compareColumn = "Total Net Present Value";

    // opt daimeter
    if (len === 1) {
        const dOnly = dtDatas[0]?.["Diameter"];
        if (outEl) outEl.value = dOnly ?? '';
        return;
    }

   
    let j = 1;

    let z = toNum(dtDatas2[j]?.[compareColumn]);
    let d1 = toNum(dtDatas[j]?.["Diameter"]);

    // Track the "best so far"
    let bestZ = z;
    let bestD = d1;

    if (dbgZ) dbgZ.value = Number.isFinite(bestZ) ? String(bestZ) : '';
    if (dbgD) dbgD.value = Number.isFinite(bestD) ? String(bestD) : '';


    do {
        z = toNum(dtDatas2[j]?.[compareColumn]);
        d1 = toNum(dtDatas[j]?.["Diameter"]);


        const z1 = toNum(dtDatas2[j - 1]?.[compareColumn]);
        const d2 = toNum(dtDatas[j - 1]?.["Diameter"]);

        // Optional debug mirrors your assignments
        if (dbg50) dbg50.value = Number.isFinite(z) ? String(z) : '';
        if (dbg52) dbg52.value = Number.isFinite(z1) ? String(z1) : '';
        if (dbg51) dbg51.value = Number.isFinite(d1) ? String(d1) : '';
        if (dbg53) dbg53.value = Number.isFinite(d2) ? String(d2) : '';

        // Skip if any comparison value is invalid
        if (!Number.isFinite(z) || !Number.isFinite(z1)) {
            j++;
            continue;
        }

        const z2 = Math.min(z, z1);


        if (!(Number.isFinite(bestZ))) {
            if (z <= z1) {
                bestZ = z; bestD = d1;
            } else {
                bestZ = z1; bestD = d2;
            }
        } else if (z2 <= bestZ) {

            if (z <= z1) {
                bestZ = z;
                bestD = d1;
            } else {
                bestZ = z1;
                bestD = d2;
            }
        }

        if (dbgZ) dbgZ.value = Number.isFinite(bestZ) ? String(bestZ) : '';
        if (dbgD) dbgD.value = Number.isFinite(bestD) ? String(bestD) : '';

        j++;
    } while (j < len);


    if (outEl) outEl.value = Number.isFinite(bestD) ? String(bestD) : '';


}


function buttonFourClick() {

    document.getElementById("button5").disabled = false;
    // document.getElementById("button4").disabled = true;

    flow1 = parseFloat(document.getElementById("TextBox1").value);
    flow2 = parseFloat(document.getElementById("TextBox2").value);
    phour = parseFloat(document.getElementById("TextBox3").value);

    flowphr1 = flow1 * 1000 / phour;
    flowphr2 = flow2 * 1000 / phour;
    flowps1 = flowphr1 / 3600;
    flowps2 = flowphr2 / 3600;
    flow_total = flowps1 + flowps2;
    dmax = Math.sqrt(4 * flowps2 / 3.14 * 1.8) * 1000;
    dmin = Math.sqrt(4 * flowps2 / 3.14 * 0.6) * 1000;

    document.getElementById("TextBox94").value = Math.round(dmax).toString()
    document.getElementById("TextBox95").value = Math.round(dmin).toString()
}


let TextBox23;

function buttonFiveClick() {

    if (!ValidateData()) {
        return;
    }

    document.getElementById("button_calc").disabled = false;
    document.getElementById("button5").disabled = true;

    TextBox23 = parseFloat(document.getElementById("TextBox23").value);


    flow1 = parseFloat(document.getElementById("TextBox1").value);
    flow2 = parseFloat(document.getElementById("TextBox2").value);
    phour = parseFloat(document.getElementById("TextBox3").value);
    l_pmain = parseFloat(document.getElementById("TextBox4").value);
    dis_elv = parseFloat(document.getElementById("TextBox5").value);
    low_level = parseFloat(document.getElementById("TextBox6").value);
    res_head = parseFloat(document.getElementById("TextBox7").value);
    stn_loss = parseFloat(document.getElementById("TextBox8").value);

    //d = document.getElementById("TextBox39").value;

    tw = parseFloat(document.getElementById("txt_tw").value);
    id = parseFloat(document.getElementById("txt_di").value);
    k = parseFloat(document.getElementById("txt_k").value);
    E = parseFloat(document.getElementById("txt_E").value);
    pr1 = parseFloat(document.getElementById("txt_pr1").value);

    flowphr1 = flow1 * 1000 / phour;
    flowphr2 = flow2 * 1000 / phour;
    flowps1 = flowphr1 / 3600;
    flowps2 = flowphr2 / 3600;

    vel_act = flowps1 / (0.7854 * Math.pow((id / 1000), 2));
    vel_act2 = flowps2 / (0.7854 * Math.pow((id / 1000), 2));

    loss_friction = Math.pow((flowphr1 / (1.292 * 0.00001 * TextBox23 * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;
    loss_friction2 = Math.pow((flowphr2 / (1.292 * 0.00001 * TextBox23 * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;
    loss_minor = 0.07 * loss_friction;
    loss_minor2 = 0.07 * loss_friction2;
    st_head = dis_elv - low_level;
    pump_head = loss_friction + loss_minor + st_head + res_head + stn_loss;
    pump_head2 = loss_friction2 + loss_minor2 + st_head + res_head + stn_loss;
    w_hammer1 = (vel_act / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
    w_hammer2 = (vel_act2 / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));

    pr_ratio1 = (w_hammer1 + pump_head) / (pr1);
    pr_ratio2 = (w_hammer2 + pump_head2) / (pr1);



    document.getElementById("txt_waterhammer_1").value = w_hammer1.toFixed(2);
    document.getElementById("txt_waterhammer_2").value = w_hammer2.toFixed(2);

    document.getElementById("txtpump_head").value = Number(pump_head).toFixed(2);
    document.getElementById("txtpump_head2").value = Number(pump_head2).toFixed(2);



    if (pr_ratio1 < 1.1) {
        Label3.classList.remove("d-none");

        Label1.classList.add("d-none");
        Label2.classList.add("d-none");

    }
    else if (pr_ratio1 >= 1.1 && pr_ratio1 <= 1.5) {
        Label2.classList.remove("d-none");

        Label1.classList.add("d-none");
        Label3.classList.add("d-none");
    }
    else if (pr_ratio1 > 1.5) {
        Label1.classList.remove("d-none");

        Label2.classList.add("d-none");
        Label3.classList.add("d-none");
    }


    if (pr_ratio2 <= 1.1) {
        Label6.classList.remove("d-none");

        Label4.classList.add("d-none");
        Label5.classList.add("d-none");
    }
    else if (pr_ratio2 >= 1.1 && pr_ratio2 <= 1.5) {
        Label5.classList.remove("d-none");

        Label4.classList.add("d-none");
        Label6.classList.add("d-none");
    }
    else if (pr_ratio2 > 1.5) {
        Label4.classList.remove("d-none");

        Label5.classList.add("d-none");
        Label6.classList.add("d-none");
    }
}

function refreshButton() {
    document.getElementById("refresh_button").disabled = true;
    document.getElementById("result_button").disabled = true;
    //document.getElementById("continue_button").disabled = true;
    document.getElementById("button4").disabled = false;
    document.getElementById("button5").disabled = false;


    document.getElementById("txt_di").value = "";
    document.getElementById("TextBox38").value = "";
    document.getElementById("txtact_vel").value = "";
    document.getElementById("TextBox78").value = "";
    document.getElementById("txtpump_head").value = "";
    document.getElementById("txtpump_kw").value = "";
    document.getElementById("txt_waterhammer_1").value = "";
    document.getElementById("txtcost_pumpset").value = "";
    document.getElementById("txtXf").value = "";
    document.getElementById("txtpow_py").value = "";
    document.getElementById("txtpw_pipe").value = "";
    document.getElementById("txtpw_pipeline_om").value = "";
    document.getElementById("txtpw_pumpset").value = "";
    document.getElementById("txtpw_pumpset_om").value = "";
    document.getElementById("txtpw_pow_cost").value = "";
    document.getElementById("txttotal_pw1").value = "";
    document.getElementById("TextBox99").value = "";
    document.getElementById("txtact_vel2").value = "";
    document.getElementById("TextBox98").value = "";
    document.getElementById("txtpump_head2").value = "";
    document.getElementById("txtpump_kw2").value = "";
    document.getElementById("txt_waterhammer_2").value = "";
    document.getElementById("txtpw_replace").value = "";
    document.getElementById("txtpow_py2").value = "";
    document.getElementById("txtunitrate").value = "";
    document.getElementById("txtpw_pumpset2").value = "";
    document.getElementById("txtpw_pumpset_om2").value = "";
    document.getElementById("txtpw_pow_cost2").value = "";
    document.getElementById("txttotal_pw2").value = "";
    document.getElementById("txttotal_pw").value = "";

}

function continueButton() {
    document.getElementById("optimum_diameter_button").disabled = false;
    document.getElementById("continue_button").disabled = true;

}




function outPutPanel() {
    $('#projectDetails').show('easy');
}


/*Helpers for GenerateOutput */
function toSciTrimmed(num, decimals = 2) {
    let s = num.toExponential(decimals).replace('e', 'E');
    s = s.replace(/^(-?\d+)\.(\d+)(E[+-]?\d+)$/, (_, intPart, frac, exp) => {
        const trimmed = frac.replace(/0+$/, '');
        return trimmed ? `${intPart}.${trimmed}${exp}` : `${intPart}${exp}`;
    });
    return s;
}

function formatOutputValue(value) {
    if (value === null || value === undefined) return "";
    const str = String(value).trim();
    if (str === "") return "";

    const num = Number(str);
    if (!Number.isFinite(num)) return str; // keep non-numeric as-is

    const abs = Math.abs(num);
    if (abs >= 1e10) return toSciTrimmed(num, 2);   // scientific
    if (abs >= 1e8) return String(Math.round(num)); // integer

    // < 1e8: up to 2 decimals if there were decimals, else integer
    const hadDot = str.includes('.');
    if (hadDot) return (Math.round(num * 100) / 100).toFixed(2);
    return String(Math.round(num));
}

function getRows(tableSelector, expectedCols, formatCell) {
    const rows = [];
    document.querySelectorAll(`${tableSelector} tbody tr`).forEach(tr => {
        const tds = Array.from(tr.querySelectorAll("td"));
        const row = [];
        for (let i = 0; i < expectedCols; i++) {
            const raw = (tds[i]?.innerText || "").trim();
            row.push(formatCell ? formatCell(raw, i) : raw);
        }
        rows.push(row);
    });
    return rows;
}


function GenerateOutput(param) {
    
    const jno = $("#jno").val();
    const InputDataEntryDate = $("#InputDataEntryDate").val();
    const client = $("#client").val();
    const subject = $("#subject").val();
    const projectTitle = $("#projectTitle").val();
    const docno = $("#docno").val();
    const cbydate = $("#cbydate").val();
    const BU = $("#BU").val();
    const dc = $("#dc").val();
    const revno = $("#revno").val();
    const txtdia_opt = $("#txtdia_opt").val();


    const dtDatas1 = getRows("#gv2", 28, formatOutputValue);
    const dtDatas2 = getRows("#gv3", 12, formatOutputValue);
    const dtDatas = getRows("#gv1", 16, formatOutputValue);


    
    const payload = {
        jno,
        InputDataEntryDate,
        client,
        subject,
        projectTitle,
        docno,
        cbydate,
        BU,
        dc,
        revno,
        txtdia_opt,
        dtDatas,
        dtDatas1,
        dtDatas2
    };

    const jsonData = JSON.stringify(payload);
    console.log(jsonData);
    ProcesssPDF(
        "/WasteWater/FinalReport_OptMainDiameterForWaterSupply",
        jsonData,
        param,
        "Result_opmain.pdf"
    );
}

