// global variables
let flow1, standby, flow2, phour, l_pmain, dis_elv, low_level, res_head, stn_loss, pow_tariff, esc_pow_tariff, ann_rate, esc_ann_rate;
let m, n, n1, n2, l_pipe, l_pump, vmax, vmin, pump_eff, motor_eff, cost_pump, omfac_pipe, omfac_pump, flow_total, dmax, dmin;
let flowphr1, flowphr2, flowps1, flowps2, d = 0, vel_act, unit_rate = 0, cost_pipeline, loss_friction, loss_minor, st_head, pump_head, pump_kw;
let vel_act2, loss_friction2, loss_minor2, pump_head2, w_hammer1, w_hammer2, pump_kw2, cost_pumpset2, pow_py2, pow_costfy2, om_pumpset_py2, pw_pumpset_om2, total_pw1, total_pw2;
let cost_pumpset, pow_py, pow_costfy, om_pumpset_py, om_pipe_py, cost_pumpset_15y, Xf, pw_replace, pw_pow_cost, pw_pipeline_om, pw_pumpset_om, total_pw;
let tw, id, k, E, pr1, pr2, pr_ratio1, pr_ratio2, pw_pow_cost2, total_pw_pow_cost;
let pop1, pop2, pf1, pf2, avg_flowps1, avg_flowps2, peak_flowps1, peak_flowps2, pkfac_1, pkfac_2, non_peaktme, pump_tme, peak_tme, pw_capcostpumpset2;
let avg_flowphr1, avg_flowphr2, peak_flowphr1, peak_flowphr2, balflw1, balflw2;
let peak_flow1, peak_flow2, nonpeak_hrflw1, nonpeak_hrflw2, nonpeak_tme, loss_frictionpk, loss_frictionpk2, loss_minor1peak, loss_minor2peak, pump_headpk, pump_headpk2, pump_kwpk, pump_kwpk2, tot_pumpkw1, tot_pumpkw2;
let pow_pkpy1, pow_pkpy2, pow_nonpk1, pow_nonpk2, life_stage1plusstage2, stag2_year;

// helper functions
function getValue(id) {
    const el = document.getElementById(id);
    if (!el) return 0;
    if (el.type === 'select-one') {
        return parseFloat(el.value) || 0;
    }
    return parseFloat(el.value) || 0;
}

function setValue(id, value) {
    const el = document.getElementById(id);
    if (el) el.value = value;
}

function showElement(id, show) {
    const el = document.getElementById(id);
    if (el) el.classList.toggle('d-none', !show);
}

// material selection handler
document.getElementById('ddlm').addEventListener('change', function () {
    const selected = this.value;
    ['paneld1', 'paneld2', 'paneld3', 'paneld4', 'paneld5', 'paneld6'].forEach(id => showElement(id, false));

    let cValue = 0;
    let dropdownId = '';

    switch (selected) {
        case 'DI':
            showElement('paneld1', true);
            cValue = 130;
            dropdownId = 'ddld1';
            break;
        case 'CI':
            showElement('paneld2', true);
            cValue = 130;
            dropdownId = 'ddld2';
            break;
        case 'HDPE':
            showElement('paneld3', true);
            cValue = 140;
            dropdownId = 'ddld3';
            break;
        case 'MS':
            showElement('paneld4', true);
            cValue = 130;
            dropdownId = 'ddld4';
            break;
        case 'GRP':
            showElement('paneld5', true);
            cValue = 140;
            dropdownId = 'ddld5';
            break;
        case 'PSC':
            showElement('paneld6', true);
            cValue = 130;
            dropdownId = 'ddld6';
            break;
    }

    setValue('TextBox28', cValue);
    setValue('txt_di', '');

    checkButton4Enable();
});

['ddld1', 'ddld2', 'ddld3', 'ddld4', 'ddld5', 'ddld6'].forEach(id => {
    document.getElementById(id).addEventListener('change', function () {
        d = parseFloat(this.value);
    });
});

function checkButton4Enable() {
    document.getElementById('button4').disabled = false;
}

const txtBox20 = document.getElementById('TextBox20');
if (txtBox20) {
    txtBox20.addEventListener('input', checkButton4Enable);
}

// Button 4 (max & min diameter)
function buttonFourClick() {
    const resBtn = document.getElementById('result_button'); if (resBtn) resBtn.disabled = true;
    const contBtn = document.getElementById('continue_button'); if (contBtn) contBtn.disabled = true;
    const optBtn = document.getElementById('optimum_diameter_button'); if (optBtn) optBtn.disabled = true;

    pump_tme = getValue('TextBox5');
    peak_tme = getValue('TextBox7');
    non_peaktme = pump_tme - peak_tme;
    setValue('TextBox8', non_peaktme);

    pop1 = getValue('TextBox1');
    if (pop1 < 10000) {
        pf1 = 5 / Math.pow((pop1 / 1000), 0.2);
    } else if (pop1 >= 10000 && pop1 < 20000) {
        pf1 = 3;
    } else if (pop1 >= 20000 && pop1 < 50000) {
        pf1 = 2.5;
    } else if (pop1 >= 50000 && pop1 < 750000) {
        pf1 = 2.25;
    } else if (pop1 >= 750000) {
        pf1 = 2;
    }
    setValue('TextBox9', pf1);

    pop2 = getValue('TextBox2');
    if (pop2 < 10000) {
        pf2 = 5 / Math.pow((pop2 / 1000), 0.2);
    } else if (pop2 >= 10000 && pop2 < 20000) {
        pf2 = 3;
    } else if (pop2 >= 20000 && pop2 < 50000) {
        pf2 = 2.5;
    } else if (pop2 >= 50000 && pop2 < 750000) {
        pf2 = 2.25;
    } else if (pop2 >= 750000) {
        pf2 = 2;
    }
    setValue('TextBox10', pf2);

    flow1 = getValue('TextBox3');
    flow2 = getValue('TextBox4');
    phour = getValue('TextBox5');
    pkfac_1 = getValue('TextBox9');
    pkfac_2 = getValue('TextBox10');
    peak_tme = getValue('TextBox7');
    nonpeak_tme = getValue('TextBox8');

    avg_flowphr1 = flow1 * 1000 / phour;
    avg_flowphr2 = flow2 * 1000 / phour;

    peak_flowphr1 = avg_flowphr1 * pkfac_1;
    peak_flowphr2 = avg_flowphr2 * pkfac_2;

    peak_flow1 = avg_flowphr1 * pkfac_1 * peak_tme;
    peak_flow2 = avg_flowphr2 * pkfac_2 * peak_tme;

    balflw1 = (flow1 * 1000 - peak_flow1);
    balflw2 = (flow2 * 1000 - peak_flow2);

    nonpeak_hrflw1 = balflw1 / nonpeak_tme;
    nonpeak_hrflw2 = balflw2 / nonpeak_tme;

    avg_flowps1 = flow1 * 1000 / (phour * 3600);
    avg_flowps2 = flow2 * 1000 / (phour * 3600);
    peak_flowps1 = avg_flowps1 * pkfac_1;
    peak_flowps2 = avg_flowps2 * pkfac_2;

    dmax = Math.sqrt(4 * peak_flowps2 / (Math.PI * 1.2)) * 1000;
    dmin = Math.sqrt(4 * peak_flowps2 / (Math.PI * 3)) * 1000;

    setValue('TextBox94', Math.round(dmax));
    setValue('TextBox95', Math.round(dmin));

    setValue('TextBox30', Math.round(avg_flowphr1 * 100) / 100);
    setValue('TextBox31', Math.round(avg_flowphr2 * 100) / 100);
    setValue('TextBox32', Math.round(peak_flow1 * 100) / 100);
    setValue('TextBox33', Math.round(peak_flow2 * 100) / 100);
    setValue('TextBox36', Math.round(balflw1 * 100) / 100);
    setValue('TextBox37', Math.round(balflw2 * 100) / 100);
    setValue('TextBox34', Math.round(peak_flowphr1 * 100) / 100);
    setValue('TextBox35', Math.round(peak_flowphr2 * 100) / 100);
    setValue('TextBox38', Math.round(nonpeak_hrflw1 * 100) / 100);
    setValue('TextBox39', Math.round(nonpeak_hrflw2 * 100) / 100);

    document.getElementById('button5').disabled = false;
}

// Button 5 (water hammer check)
function buttonFiveClick() {
    id = getValue('txt_di');
    tw = getValue('txt_tw');
    k = getValue('txt_k');
    E = getValue('txt_E');
    pr1 = getValue('txt_pr1');

    vel_act = peak_flowps1 / (0.7854 * Math.pow((id / 1000), 2));
    vel_act2 = peak_flowps2 / (0.7854 * Math.pow((id / 1000), 2));

    w_hammer1 = (vel_act / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
    w_hammer2 = (vel_act2 / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));

    if (w_hammer1 > pr1) {
        showElement('Label1', true);
        showElement('Label2', false);
        showElement('Label3', false);
    } else if (w_hammer1 > pr1 * 0.8) {
        showElement('Label1', false);
        showElement('Label2', true);
        showElement('Label3', false);
    } else {
        showElement('Label1', false);
        showElement('Label2', false);
        showElement('Label3', true);
    }

    if (w_hammer2 > pr1) {
        showElement('Label4', true);
        showElement('Label5', false);
        showElement('Label6', false);
    } else if (w_hammer2 > pr1 * 0.8) {
        showElement('Label4', false);
        showElement('Label5', true);
        showElement('Label6', false);
    } else {
        showElement('Label4', false);
        showElement('Label5', false);
        showElement('Label6', true);
    }

    document.getElementById('button_calc').disabled = false;
    document.getElementById('button5').disabled = true;

    document.getElementById('button4').disabled = false;
}

// Button calculate click
function buttonCalcClick() {
    flow1 = getValue('TextBox3');
    flow2 = getValue('TextBox4');
    phour = getValue('TextBox5');
    pkfac_1 = getValue('TextBox9');
    pkfac_2 = getValue('TextBox10');
    peak_tme = getValue('TextBox7');
    nonpeak_tme = getValue('TextBox8');

    l_pmain = getValue('TextBox6');
    dis_elv = getValue('TextBox13');
    low_level = getValue('TextBox14');
    res_head = getValue('TextBox15');
    stn_loss = getValue('TextBox16');
    pow_tariff = getValue('TextBox17');
    esc_pow_tariff = getValue('TextBox18');
    ann_rate = getValue('TextBox11');
    esc_ann_rate = getValue('TextBox12');
    n = getValue('No_of_years_1');
    stag2_year = getValue('No_of_years_2');
    l_pipe = getValue('TextBox21');
    l_pump = getValue('TextBox22');

    pump_eff = getValue('TextBox23');
    motor_eff = getValue('TextBox24');
    cost_pump = getValue('TextBox25');
    omfac_pump = getValue('TextBox26');
    omfac_pipe = getValue('TextBox27');
    standby = getValue('TextBox29');

    tw = getValue('txt_tw');
    id = getValue('txt_di');
    k = getValue('txt_k');
    E = getValue('txt_E');

    avg_flowphr1 = (flow1 * 1000) / phour;
    avg_flowphr2 = (flow2 * 1000) / phour;

    avg_flowps1 = (flow1 * 1000) / (phour * 3600);
    avg_flowps2 = (flow2 * 1000) / (phour * 3600);

    peak_flowphr1 = (avg_flowphr1 * pkfac_1);
    peak_flowphr2 = (avg_flowphr2 * pkfac_2);

    peak_flowps1 = (avg_flowps1 * pkfac_1);
    peak_flowps2 = (avg_flowps2 * pkfac_2);

    peak_flow1 = (avg_flowphr1 * pkfac_1 * peak_tme);
    peak_flow2 = (avg_flowphr2 * pkfac_2 * peak_tme);

    balflw1 = ((flow1 * 1000) - peak_flow1);
    balflw2 = ((flow2 * 1000) - peak_flow2);

    nonpeak_hrflw1 = (balflw1 / nonpeak_tme);
    nonpeak_hrflw2 = (balflw2 / nonpeak_tme);

    vel_act = peak_flowps1 / (0.7854 * Math.pow((id / 1000), 2));
    vel_act2 = peak_flowps2 / (0.7854 * Math.pow((id / 1000), 2));

    cost_pipeline = getValue('TextBox96') * l_pmain / 100000;

    loss_frictionpk = Math.pow(((peak_flowphr1) / (1.292 * 0.00001 * getValue('TextBox28') * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;
    loss_frictionpk2 = Math.pow(((peak_flowphr2) / (1.292 * 0.00001 * getValue('TextBox28') * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;

    loss_friction = Math.pow(((nonpeak_hrflw1) / (1.292 * 0.00001 * getValue('TextBox28') * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;
    loss_friction2 = Math.pow(((nonpeak_hrflw2) / (1.292 * 0.00001 * getValue('TextBox28') * Math.pow(id, 2.63))), (1 / 0.54)) * l_pmain;

    loss_minor1peak = 0.07 * loss_frictionpk;
    loss_minor2peak = 0.07 * loss_frictionpk2;

    loss_minor = 0.07 * loss_friction;
    loss_minor2 = 0.07 * loss_friction2;

    st_head = dis_elv - low_level;

    pump_headpk = loss_frictionpk + loss_minor1peak + st_head + res_head + stn_loss;
    pump_headpk2 = loss_frictionpk2 + loss_minor2peak + st_head + res_head + stn_loss;

    pump_head = loss_friction + loss_minor + st_head + res_head + stn_loss;
    pump_head2 = loss_friction2 + loss_minor2 + st_head + res_head + stn_loss;

    w_hammer1 = (vel_act / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));
    w_hammer2 = (vel_act2 / 9.81) * (1425 / Math.sqrt(1 + ((k * (id / 1000)) / (E * (tw / 1000)))));

    pump_kwpk = ((peak_flowphr1) * pump_headpk) / (367.25 * (pump_eff / 100) * (motor_eff / 100));
    pump_kwpk2 = ((peak_flowphr2) * pump_headpk2) / (367.25 * (pump_eff / 100) * (motor_eff / 100));

    pump_kw = ((nonpeak_hrflw1) * pump_head) / (367.25 * (pump_eff / 100) * (motor_eff / 100));
    pump_kw2 = ((nonpeak_hrflw2) * pump_head2) / (367.25 * (pump_eff / 100) * (motor_eff / 100));

    tot_pumpkw1 = pump_kwpk + pump_kw;
    tot_pumpkw2 = pump_kwpk2 + pump_kw2;

    cost_pumpset = pump_kwpk * (1 + (standby / 100)) * cost_pump / 100000;

    cost_pumpset2 = pump_kwpk2 * (1 + (standby / 100)) * cost_pump / 100000;

    cost_pumpset_15y = cost_pumpset2 * Math.pow(1 + (esc_ann_rate / 100), 15);

    pw_capcostpumpset2 = cost_pumpset_15y / Math.pow(1 + (ann_rate / 100), l_pump);

    pow_pkpy1 = pump_kwpk * peak_tme * 365;
    pow_pkpy2 = pump_kwpk2 * peak_tme * 365;

    pow_nonpk1 = pump_kw * nonpeak_tme * 365;
    pow_nonpk2 = pump_kw2 * nonpeak_tme * 365;

    pow_py = pow_pkpy1 + pow_nonpk1;
    pow_py2 = pow_pkpy2 + pow_nonpk2;

    pow_costfy = pow_py * pow_tariff / 100000;
    pow_costfy2 = pow_py2 * pow_tariff / 100000;

    om_pumpset_py = omfac_pump / 100 * cost_pumpset;
    om_pumpset_py2 = omfac_pump / 100 * cost_pumpset2;

    om_pipe_py = omfac_pipe / 100 * cost_pipeline;

    Xf = (1 + (esc_ann_rate / 100)) / (1 + (ann_rate / 100));

    pw_replace = cost_pumpset_15y / Math.pow((1 + (ann_rate / 100)), l_pump);

    pw_pow_cost = pow_costfy * Xf * (1 - Math.pow(Xf, n)) / (1 - Xf);

    pw_pow_cost2 = (pow_costfy2 / (Math.pow((1 + ann_rate / 100), l_pump))) * Xf * (1 - Math.pow(Xf, l_pipe)) / (1 - Xf);

    total_pw_pow_cost = pw_pow_cost + pw_pow_cost2;

    pw_pipeline_om = om_pipe_py * Xf * (1 - Math.pow(Xf, l_pipe)) / (1 - Xf);

    pw_pumpset_om = om_pumpset_py * Xf * (1 - Math.pow(Xf, l_pump)) / (1 - Xf);

    life_stage1plusstage2 = (n + stag2_year);
    pw_pumpset_om2 = (om_pumpset_py2 / (Math.pow((1 + ann_rate / 100), l_pump))) * Xf * (1 - Math.pow(Xf, l_pipe)) / (1 - Xf);

    total_pw1 = cost_pumpset + pw_pow_cost + pw_pumpset_om;

    total_pw2 = pw_capcostpumpset2 + pw_pow_cost2 + pw_pumpset_om2;

    total_pw = (pw_pipeline_om + cost_pipeline) + (cost_pumpset + pw_capcostpumpset2 + pw_pumpset_om + pw_pumpset_om2) + (pw_pow_cost + pw_pow_cost2);

    setValue('res_actualVelocity_stage1', Math.round(vel_act * 100) / 100);
    setValue('res_actualVelocity_stage2', Math.round(vel_act2 * 100) / 100);
    setValue('res_friction_peak_stage1', Math.round(loss_frictionpk * 100) / 100);
    setValue('res_friction_peak_stage2', Math.round(loss_frictionpk2 * 100) / 100);
    setValue('res_friction_nonpeak_stage1', Math.round(loss_friction * 100) / 100);
    setValue('res_friction_nonpeak_stage2', Math.round(loss_friction2 * 100) / 100);
    setValue('res_totalHead_peak_stage1', Math.round(pump_headpk * 100) / 100);
    setValue('res_totalHead_peak_stage2', Math.round(pump_headpk2 * 100) / 100);
    setValue('res_totalHead_nonpeak_stage1', Math.round(pump_head * 100) / 100);
    setValue('res_totalHead_nonpeak_stage2', Math.round(pump_head2 * 100) / 100);
    setValue('res_pumpKW_peak_stage1', Math.round(pump_kwpk * 100) / 100);
    setValue('res_pumpKW_peak_stage2', Math.round(pump_kwpk2 * 100) / 100);
    setValue('res_pumpKW_nonpeak_stage1', Math.round(pump_kw * 100) / 100);
    setValue('res_pumpKW_nonpeak_stage2', Math.round(pump_kw2 * 100) / 100);
    setValue('res_totalPumpKW_stage1', Math.round(tot_pumpkw1 * 100) / 100);
    setValue('res_totalPumpKW_stage2', Math.round(tot_pumpkw2 * 100) / 100);
    setValue('res_waterHammer_stage1', Math.round(w_hammer1 * 100) / 100);
    setValue('res_waterHammer_stage2', Math.round(w_hammer2 * 100) / 100);
    setValue('res_capitalCost_pumpsets_stage1', Math.round(cost_pumpset * 100) / 100);
    setValue('res_npv_replacement_stage2', Math.round(cost_pumpset2 * 100) / 100);
    setValue('res_capitalCost_pumpsets_stage1_2', Math.round(cost_pumpset * 100) / 100);
    setValue('res_npv_replacement_stage2_2', Math.round(cost_pumpset2 * 100) / 100);
    setValue('res_x_factor', Math.round(Xf * 1000) / 1000);
    setValue('res_power_year_peak_stage1', Math.round(pow_pkpy1 * 100) / 100);
    setValue('res_power_year_peak_stage2', Math.round(pow_pkpy2 * 100) / 100);
    setValue('res_power_year_nonpeak_stage1', Math.round(pow_nonpk1 * 100) / 100);
    setValue('res_power_year_nonpeak_stage2', Math.round(pow_nonpk2 * 100) / 100);

    setValue('res_totalPowerYear_stage1', Math.round(pow_py * 100) / 100);
    setValue('res_totalPowerYear_stage2', Math.round(pow_py2 * 100) / 100);

    setValue('res_powerCost_perYear_stage1', Math.round(pow_costfy * 100) / 100);
    setValue('res_powerCost_perYear_stage2', Math.round(pow_costfy2 * 100) / 100);

    setValue('res_npv_capital_pipeline', Math.round(cost_pipeline * 100) / 100);
    setValue('res_cost_pipeline_perRm', Math.round(getValue('TextBox96') * 100) / 100);
    setValue('res_npv_OM_pipeline', Math.round(pw_pipeline_om * 100) / 100);

    setValue('res_cost_pumpsets_after15', Math.round(cost_pumpset_15y * 100) / 100);

    setValue('res_OM_pumpsets_year_stage1', Math.round(om_pumpset_py * 100) / 100);
    setValue('res_OM_pumpsets_year_stage2', Math.round(om_pumpset_py2 * 100) / 100);

    setValue('res_OM_pipeline_year_stage1', Math.round(om_pipe_py * 100) / 100);
    setValue('res_OM_pipeline_year_stage2', Math.round(om_pipe_py * 100) / 100);

    setValue('res_npv_capital_pumpsets_stage1', Math.round(cost_pumpset * 100) / 100);
    setValue('res_npv_capital_pumpsets_stage2', Math.round(pw_capcostpumpset2 * 100) / 100);

    setValue('res_replacement_cost_pumpsets_present_stage2', Math.round(pw_capcostpumpset2 * 100) / 100);

    setValue('res_npv_OM_pumpsets_stage1', Math.round(pw_pumpset_om * 100) / 100);
    setValue('res_npv_OM_pumpsets_stage2', Math.round(pw_pumpset_om2 * 100) / 100);

    setValue('res_npv_power_stage1', Math.round(pw_pow_cost * 100) / 100);
    setValue('res_npv_power_stage2', Math.round(pw_pow_cost2 * 100) / 100);

    setValue('res_total_npv_stage1', Math.round(total_pw1 * 100) / 100);
    setValue('res_total_npv_stage2', Math.round(total_pw2 * 100) / 100);

    setValue('res_net_total_power_cost', Math.round(total_pw_pow_cost * 100) / 100);
    setValue('res_total_npv_all', Math.round(total_pw * 100) / 100);

    const resBtn = document.getElementById('result_button');
    if (resBtn) resBtn.disabled = false;
    const refBtn = document.getElementById('refresh_button');
    if (refBtn) refBtn.disabled = false;
    const contBtn = document.getElementById('continue_button');
    if (contBtn) contBtn.disabled = false;

    document.getElementById('button4').disabled = false;
    document.getElementById('button5').disabled = true;
    document.getElementById('button_calc').disabled = true;
}

// reset form state
function refreshButton() {
    document.querySelectorAll('input[readonly]').forEach(el => el.value = '');
    document.querySelectorAll('#Label1, #Label2, #Label3, #Label4, #Label5, #Label6').forEach(el => el.classList.add('d-none'));

    document.getElementById('button4').disabled = false;    // max/min
    document.getElementById('button5').disabled = true;     // water hammer
    document.getElementById('button_calc').disabled = true; // calculate
    document.getElementById('result_button').disabled = true;
    document.getElementById('continue_button').disabled = true;
    document.getElementById('optimum_diameter_button').disabled = true;

    document.querySelectorAll('input, select').forEach(el => {
        if (!el.hasAttribute('readonly')) el.disabled = false;
    });

    ['paneld1', 'paneld2', 'paneld3', 'paneld4', 'paneld5', 'paneld6'].forEach(id => showElement(id, false));
    ['ddld1', 'ddld2', 'ddld3', 'ddld4', 'ddld5', 'ddld6'].forEach(i => {
        const e = document.getElementById(i);
        if (e) {
            e.selectedIndex = 0;
            e.disabled = false;
        }
    });

    const mat = document.getElementById('ddlm');
    if (mat) {
        mat.selectedIndex = 0;
        mat.disabled = false;
    }

    d = 0;

    ['TextBox1', 'TextBox2', 'TextBox3', 'TextBox4', 'TextBox5', 'TextBox6', 'TextBox7', 'TextBox8', 'TextBox9', 'TextBox10', 'TextBox11', 'TextBox12', 'TextBox13', 'TextBox14', 'TextBox15', 'TextBox16', 'TextBox17', 'TextBox18', 'TextBox19', 'TextBox20', 'TextBox21', 'TextBox22', 'TextBox23', 'TextBox24', 'TextBox25', 'TextBox26', 'TextBox27', 'TextBox28', 'TextBox29', 'TextBox96', 'txt_di', 'txt_tw', 'txt_k', 'txt_E', 'txt_pr1'].forEach(id => {
        const el = document.getElementById(id);
        if (el && !el.hasAttribute('readonly')) el.value = el.type === 'number' ? '' : '';
    });
}

// continue button handler
function continueButton() {
    const opt = document.getElementById('optimum_diameter_button');
    if (opt) opt.disabled = false;
    const cont = document.getElementById('continue_button');
    if (cont) cont.disabled = true;
}

// reveal output panel
function outPutPanel() {
    const panel = document.getElementById('three_tables');
    if (panel) panel.classList.remove('d-none');
}

const dtDatas = [];
const dtDatas1 = [];
const dtDatas2 = [];

function byId(id) { return document.getElementById(id); }

function renderTable(tableId, rows) {
    let container = byId(tableId);
    if (!container) {
        const parent = byId('three_tables') || document.body;
        container = document.createElement('div');
        container.id = tableId;
        container.className = 'table-responsive mt-2';
        parent.appendChild(container);
    }

    if (!rows || rows.length === 0) {
        container.innerHTML = '<p class="text-muted">No data</p>';
        return;
    }

    const cols = Object.keys(rows[0]);
    let html = '<table class="table table-bordered table-sm text-center"><thead class="bg-secondary text-white"><tr>';
    for (const c of cols) html += `<th>${c}</th>`;
    html += '</tr></thead><tbody>';
    for (const r of rows) {
        html += '<tr>';
        for (const c of cols) html += `<td>${r[c] ?? ''}</td>`;
        html += '</tr>';
    }
    html += '</tbody></table>';
    container.innerHTML = html;
}

function getStr(id) {
    const el = byId(id);
    if (!el) return '';
    return (el.value !== undefined && el.value !== null) ? String(el.value) : String(el.textContent || '');
}

function addResult() {
    try {
        const resBtn = byId('result_button');
        if (resBtn) resBtn.disabled = true;
        const cont = byId('continue_button'); if (cont) cont.disabled = false;
        const ref = byId('refresh_button'); if (ref) ref.disabled = false;

        const three = byId('three_tables'); if (three) three.classList.remove('d-none');

        function currentNominal() {
            const ids = ['ddld1', 'ddld2', 'ddld3', 'ddld4', 'ddld5', 'ddld6'];
            for (const id of ids) {
                const sel = document.getElementById(id);
                if (sel && !sel.closest('.d-none') && sel.value) {
                    return sel.value;
                }
            }
            return getStr('TextBox94') || getStr('txtdia_opt');
        }

        const row1 = {
            'Diameter': currentNominal(),
            'Inner Diameter': getStr('txt_di'),
            'Average Hourly Flow for Stage I': getStr('TextBox30'),
            'Total Flow in Peak Flow Hours for Stage I': getStr('TextBox32'),
            'Hourly Peak Flow for Stage I': getStr('TextBox34'),
            'Balance Flow during Non Peak Flow Hours for Stage I': getStr('TextBox36'),
            'Non Peak Flow Hourly demand for Stage I': getStr('TextBox38'),
            'Actual velocity_StageI': getStr('res_actualVelocity_stage1'),
            'Pipe Friction Loss for Stage I during Peak Flow': getStr('res_friction_peak_stage1'),
            'Pipe Friction Loss for Stage I during Non Peak Flow': getStr('res_friction_nonpeak_stage1'),
            'Total Pump Head for Stage I during Peak Flow': getStr('res_totalHead_peak_stage1'),
            'Total Pump Head for Stage I during Non Peak Flow': getStr('res_totalHead_nonpeak_stage1'),
            'Pump kW for Stage I during Peak flow': getStr('res_pumpKW_peak_stage1'),
            'Pump kW for Stage I during Non Peak Flow': getStr('res_pumpKW_nonpeak_stage1'),
            'Water Hammer Head for Stage I': getStr('res_waterHammer_stage1'),
            'Capital Cost of Pumpsets for Stage I': getStr('res_capitalCost_pumpsets_stage1'),
            'X factor': getStr('res_x_factor'),
            'Power Required in One Year for Stage I during Peak Flow': getStr('res_power_year_peak_stage1'),
            'Power Required in One Year for Stage I during Non Peak Flow': getStr('res_power_year_nonpeak_stage1'),
            'Total Power Required in One Year for Stage I': getStr('res_totalPowerYear_stage1'),
            'Power cost for Stage I per year': getStr('res_powerCost_perYear_stage1'),
            'O&M Cost for pumpsets per year for Stage I': getStr('res_OM_pumpsets_year_stage1'),
            'O&M Cost for Pipeline per year for Stage I': getStr('res_OM_pipeline_year_stage1'),
            'Net present value of Capital Cost for Pipeline_StageI': getStr('res_npv_capital_pipeline'),
            'Net Present Value of O & M cost for Pipeline_StageI': getStr('res_npv_OM_pipeline'),
            'Net present value of Capital Cost for Pumpsets_StageI': getStr('res_npv_capital_pumpsets_stage1'),
            'Net Present Value of O & M cost for Pumpsets_StageI': getStr('res_npv_OM_pumpsets_stage1'),
            'Net Present value of Power cost_StageI': getStr('res_npv_power_stage1'),
            'Total Net Present Value for Stage I (Excluding Pipe)': getStr('res_total_npv_stage1')
        };
        dtDatas.push(row1);

        const row2 = {
            'Flow for stage 1': getStr('TextBox3'),
            'Flow for stage 2': getStr('TextBox4'),
            'Pumping hours': getStr('TextBox5'),
            'Peak flow hours per day': getStr('TextBox7'),
            'population for stage 1': getStr('TextBox1'),
            'population for stage 2': getStr('TextBox2'),
            'peak factor for stage 1': getStr('TextBox9'),
            'peak factor for stage 2': getStr('TextBox10'),
            'Length of Pumping Main': getStr('TextBox6'),
            'Discharge Point Elevation': getStr('TextBox13'),
            'Low water level at source': getStr('TextBox14'),
            'Residual Head': getStr('TextBox15'),
            'Station Losses': getStr('TextBox16'),
            'Power Tariff': getStr('TextBox17'),
            'Escalation of Power Tariff': getStr('TextBox18'),
            'Escalated rate': getStr('TextBox12'),
            'Annual Intrest Rate': getStr('TextBox11'),
            'Material Considered': getStr('ddlm'),
            'Nos of year to be considered (Design Period)': getStr('No_of_years_1'),
            'Life of Pipeline': getStr('TextBox21'),
            'Life of the pumpsets': getStr('TextBox22'),
            'Pump Efficiency': getStr('TextBox23'),
            'Motor Efficiency': getStr('TextBox24'),
            'Cost of Pumpsets': getStr('TextBox25'),
            'O & M cost factor for pumpset per year': getStr('TextBox26'),
            'O & M cost factor for pipeline per year': getStr('TextBox27'),
            'Hazen Williams Coefficient': getStr('TextBox28'),
            'Material Unit Rate': getStr('TextBox96'),
            'Wall Thickness of Pipe': getStr('txt_tw'),
            'Bulk Modulus of Water': getStr('txt_k'),
            'Modulus of Elasticity of Pipe Material': getStr('txt_E'),
            'Allowable Withstanding Pressure of Selected Pipe': getStr('txt_pr1'),
            'Proposed Standby': getStr('TextBox29')
        };
        dtDatas1.push(row2);

        const row3 = {
            'Average Hourly Flow for Stage II': getStr('TextBox31'),
            'Total Flow in Peak Flow Hours for Stage II': getStr('TextBox33'),
            'Hourly Peak Flow for Stage II': getStr('TextBox35'),
            'Balance Flow during Non Peak Flow Hours for Stage II': getStr('TextBox37'),
            'Non Peak Flow Hourly demand for Stage II': getStr('TextBox39'),
            'Actual velocity_StageII': getStr('res_actualVelocity_stage2'),
            'Pipe Friction Loss for Stage II during Peak Flow': getStr('res_friction_peak_stage2'),
            'Pipe Friction Loss for Stage II during Non Peak Flow': getStr('res_friction_nonpeak_stage2'),
            'Total Pump Head for Stage II during Peak Flow': getStr('res_totalHead_peak_stage2'),
            'Total Pump Head for Stage II during Non Peak Flow': getStr('res_totalHead_nonpeak_stage2'),
            'Pump kW for Stage II during Peak flow': getStr('res_pumpKW_peak_stage2'),
            'Pump kW for Stage II during Non Peak Flow': getStr('res_pumpKW_nonpeak_stage2'),
            'Water Hammer Head for Stage II': getStr('res_waterHammer_stage2'),
            'Capital cost of pumpsets_StageII': getStr('res_npv_replacement_stage2'),
            'Power Required in One Year for Stage II during Peak Flow': getStr('res_power_year_peak_stage2'),
            'Power Required in One Year for Stage II during Non Peak Flow': getStr('res_power_year_nonpeak_stage2'),
            'Total Power Required in One Year for Stage II': getStr('res_totalPowerYear_stage2'),
            'Power cost for Stage II per year': getStr('res_powerCost_perYear_stage2'),
            'Cost of pumpsets after 15 years for replacement': getStr('res_cost_pumpsets_after15'),
            'O&M Cost for pumpsets per year for Stage II': getStr('res_OM_pumpsets_year_stage2'),
            'O&M Cost for Pipeline per year for Stage II': getStr('res_OM_pipeline_year_stage2'),
            'Replacement Cost of Pumpsets - Present Worth i.e for stage II': getStr('res_replacement_cost_pumpsets_present_stage2'),
            'Net present value of Capital Cost for Pumpsets_StageII': getStr('res_npv_capital_pumpsets_stage2'),
            'Net Present value of Power cost_StageII': getStr('res_npv_power_stage2'),
            'Net Present Value of O & M cost for Pumpsets_StageII': getStr('res_npv_OM_pumpsets_stage2'),
            'Total Net Present Value_StageII(Excluding Pipe)': getStr('res_total_npv_stage2'),
            'Total Net Present Value': getStr('res_total_npv_all')
        };
        dtDatas2.push(row3);

        const setTd = (id, v) => {
            const el = document.getElementById(id);
            if (el) el.textContent = v;
        };

        setTd('t_flow_stage1', row2['Flow for stage 1']);
        setTd('t_flow_stage2', row2['Flow for stage 2']);
        setTd('t_pumping_hours', row2['Pumping hours']);
        setTd('t_peak_hours_per_day', row2['Peak flow hours per day']);
        setTd('t_population_stage1', row2['population for stage 1']);
        setTd('t_population_stage2', row2['population for stage 2']);
        setTd('t_peak_factor_stage1', row2['peak factor for stage 1']);
        setTd('t_peak_factor_stage2', row2['peak factor for stage 2']);
        setTd('t_length_pumping_main', row2['Length of Pumping Main']);
        setTd('t_discharge_elevation', row2['Discharge Point Elevation']);
        setTd('t_low_water_level_source', row2['Low water level at source']);
        setTd('t_residual_head', row2['Residual Head']);
        setTd('t_station_losses', row2['Station Losses']);
        setTd('t_power_tariff', row2['Power Tariff']);
        setTd('t_escalation_power_tariff', row2['Escalation of Power Tariff']);
        setTd('t_escalated_rate', row2['Escalated rate']);
        setTd('t_annual_interest_rate', row2['Annual Intrest Rate']);
        setTd('t_material_considered', row2['Material Considered']);
        setTd('t_years_design_period', row2['Nos of year to be considered (Design Period)']);
        setTd('t_life_pipeline', row2['Life of Pipeline']);
        setTd('t_life_pumpsets', row2['Life of the pumpsets']);
        setTd('t_pump_efficiency', row2['Pump Efficiency']);
        setTd('t_motor_efficiency', row2['Motor Efficiency']);
        setTd('t_cost_pumpsets', row2['Cost of Pumpsets']);
        setTd('t_om_factor_pumpset', row2['O & M cost factor for pumpset per year']);
        setTd('t_om_factor_pipeline', row2['O & M cost factor for pipeline per year']);
        setTd('t_hazen_williams_coefficient', row2['Hazen Williams Coefficient']);
        setTd('t_material_unit_rate', row2['Material Unit Rate']);
        setTd('t_wall_thickness', row2['Wall Thickness of Pipe']);
        setTd('t_bulk_modulus', row2['Bulk Modulus of Water']);
        setTd('t_modulus_elasticity', row2['Modulus of Elasticity of Pipe Material']);
        setTd('t_allowable_withstanding_pressure', row2['Allowable Withstanding Pressure of Selected Pipe']);
        setTd('t_proposed_standby', row2['Proposed Standby']);

        setTd('s2_avg_hourly_flow', row3['Average Hourly Flow for Stage II']);
        setTd('s2_total_flow_peak_hours', row3['Total Flow in Peak Flow Hours for Stage II']);
        setTd('s2_hourly_peak_flow', row3['Hourly Peak Flow for Stage II']);
        setTd('s2_balance_flow_nonpeak', row3['Balance Flow during Non Peak Flow Hours for Stage II']);
        setTd('s2_nonpeak_hourly_demand', row3['Non Peak Flow Hourly demand for Stage II']);
        setTd('s2_actual_velocity', row3['Actual velocity_StageII']);
        setTd('s2_pipe_friction_peak', row3['Pipe Friction Loss for Stage II during Peak Flow']);
        setTd('s2_pipe_friction_nonpeak', row3['Pipe Friction Loss for Stage II during Non Peak Flow']);
        setTd('s2_total_pump_head_peak', row3['Total Pump Head for Stage II during Peak Flow']);
        setTd('s2_total_pump_head_nonpeak', row3['Total Pump Head for Stage II during Non Peak Flow']);
        setTd('s2_pump_kw_peak', row3['Pump kW for Stage II during Peak flow']);
        setTd('s2_pump_kw_nonpeak', row3['Pump kW for Stage II during Non Peak Flow']);
        setTd('s2_water_hammer', row3['Water Hammer Head for Stage II']);
        setTd('s2_capital_cost_pumpsets', row3['Capital cost of pumpsets_StageII']);
        setTd('s2_power_year_peak', row3['Power Required in One Year for Stage II during Peak Flow']);
        setTd('s2_power_year_nonpeak', row3['Power Required in One Year for Stage II during Non Peak Flow']);
        setTd('s2_total_power_year', row3['Total Power Required in One Year for Stage II']);
        setTd('s2_power_cost_per_year', row3['Power cost for Stage II per year']);
        setTd('s2_cost_pumpsets_after15', row3['Cost of pumpsets after 15 years for replacement']);
        setTd('s2_om_pumpsets_year', row3['O&M Cost for pumpsets per year for Stage II']);
        setTd('s2_om_pipeline_year', row3['O&M Cost for Pipeline per year for Stage II']);
        setTd('s2_replacement_cost_present', row3['Replacement Cost of Pumpsets - Present Worth i.e for stage II']);
        setTd('s2_npv_capital_pumpsets', row3['Net present value of Capital Cost for Pumpsets_StageII']);
        setTd('s2_npv_power', row3['Net Present value of Power cost_StageII']);
        setTd('s2_npv_om_pumpsets', row3['Net Present Value of O & M cost for Pumpsets_StageII']);
        setTd('s2_total_npv_stage2', row3['Total Net Present Value_StageII(Excluding Pipe)']);
        setTd('s2_total_npv', row3['Total Net Present Value']);

        setTd('s1_diameter', row1['Diameter']);
        setTd('s1_inner_diameter', row1['Inner Diameter']);
        setTd('s1_avg_hourly_flow', row1['Average Hourly Flow for Stage I']);
        setTd('s1_total_flow_peak', row1['Total Flow in Peak Flow Hours for Stage I']);
        setTd('s1_hourly_peak_flow', row1['Hourly Peak Flow for Stage I']);
        setTd('s1_balance_flow_nonpeak', row1['Balance Flow during Non Peak Flow Hours for Stage I']);
        setTd('s1_nonpeak_hourly_demand', row1['Non Peak Flow Hourly demand for Stage I']);
        setTd('s1_actual_velocity', row1['Actual velocity_StageI']);
        setTd('s1_pipe_friction_peak', row1['Pipe Friction Loss for Stage I during Peak Flow']);
        setTd('s1_pipe_friction_nonpeak', row1['Pipe Friction Loss for Stage I during Non Peak Flow']);
        setTd('s1_total_pump_head_peak', row1['Total Pump Head for Stage I during Peak Flow']);
        setTd('s1_total_pump_head_nonpeak', row1['Total Pump Head for Stage I during Non Peak Flow']);
        setTd('s1_pump_kw_peak', row1['Pump kW for Stage I during Peak flow']);
        setTd('s1_pump_kw_nonpeak', row1['Pump kW for Stage I during Non Peak Flow']);
        setTd('s1_water_hammer', row1['Water Hammer Head for Stage I']);
        setTd('s1_capital_cost_pumpsets', row1['Capital Cost of Pumpsets for Stage I']);
        setTd('s1_x_factor', row1['X factor']);
        setTd('s1_power_year_peak', row1['Power Required in One Year for Stage I during Peak Flow']);
        setTd('s1_power_year_nonpeak', row1['Power Required in One Year for Stage I during Non Peak Flow']);
        setTd('s1_total_power_year', row1['Total Power Required in One Year for Stage I']);
        setTd('s1_power_cost_per_year', row1['Power cost for Stage I per year']);
        setTd('s1_om_pumpsets_year', row1['O&M Cost for pumpsets per year for Stage I']);
        setTd('s1_om_pipeline_year', row1['O&M Cost for Pipeline per year for Stage I']);
        setTd('s1_npv_capital_pipeline', row1['Net present value of Capital Cost for Pipeline_StageI']);
        setTd('s1_npv_om_pipeline', row1['Net Present Value of O & M cost for Pipeline_StageI']);
        setTd('s1_npv_capital_pumpsets', row1['Net present value of Capital Cost for Pumpsets_StageI']);
        setTd('s1_npv_om_pumpsets', row1['Net Present Value of O & M cost for Pumpsets_StageI']);
        setTd('s1_npv_power', row1['Net Present value of Power cost_StageI']);
        setTd('s1_total_npv_stage1', row1['Total Net Present Value for Stage I (Excluding Pipe)']);


        const mark = (id) => {
            const tbl = byId(id)?.querySelector('table');
            if (!tbl) return;
            Array.from(tbl.querySelectorAll('tbody tr')).forEach(tr => tr.classList.remove('bg-warning'));
            const last = tbl.querySelector('tbody tr:last-child'); if (last) last.classList.add('bg-warning');
        };
        mark('gv1'); mark('gv2'); mark('gv3');

        const detailed = document.getElementById('detailed_results');
        if (detailed) detailed.disabled = false;
    } catch (err) {
        console.error('addResult error', err);
        alert('Unable to add result. See console for details.');
    }
}

window.addResult = addResult;

function optimumDiameter() {
    if (!Array.isArray(dtDatas) || dtDatas.length === 0) {
        alert('No results added yet');
        return;
    }

    const len = Math.min(dtDatas.length, dtDatas2.length);

    if (len === 1) {
        const out = byId('txtdia_opt');
        if (out) out.value = dtDatas[0]['Diameter'] ?? '';
        return;
    }

    let j = 1;
    let z = parseFloat(String(dtDatas2[j]['Total Net Present Value']).replace(/,/g, '')) || 0;
    let d1 = dtDatas[j]['Diameter'];

    let bestZ = z;
    let bestD = d1;

    do {
        z = parseFloat(String(dtDatas2[j]['Total Net Present Value']).replace(/,/g, '')) || 0;
        d1 = dtDatas[j]['Diameter'];

        const z1 = parseFloat(String(dtDatas2[j - 1]['Total Net Present Value']).replace(/,/g, '')) || 0;
        const d2 = dtDatas[j - 1]['Diameter'];

        const z2 = Math.min(z, z1);

        if (z2 > bestZ) {
            break;
        } else {
            if (z <= z1) {
                bestZ = z;
                bestD = d1;
            } else if (z > z1) {
                bestZ = z1;
                bestD = d2;
            }
        }
        j++;
    } while (j < len);

    const out = byId('txtdia_opt');
    if (out) out.value = bestD ?? '';
}

window.optimumDiameter = optimumDiameter;

function setupEventListeners() {
    const btn4 = document.getElementById('button4');
    const btn5 = document.getElementById('button5');
    const btnCalc = document.getElementById('button_calc');

    if (btn4) btn4.addEventListener('click', buttonFourClick);
    if (btn5) btn5.addEventListener('click', buttonFiveClick);
    if (btnCalc) btnCalc.addEventListener('click', buttonCalcClick);

    if (btn4) btn4.disabled = false;
    if (btn5) btn5.disabled = true;
    if (btnCalc) btnCalc.disabled = true;

    checkButton4Enable();
}

setupEventListeners();