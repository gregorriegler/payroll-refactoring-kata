function payAmount(employee, workHours) {
  let result;
  if (employee.isSeparated) {
    result = { amount: 0, reasonCode: "SEP" };
  } else {
    if (employee.isRetired) {
      result = { amount: 0, reasonCode: "RET" };
    } else {
      // logic to compute amount
      payroll.preparePayment(employee.id); 
      employee.startDate = payroll.startDate;
      const bonuses = employee.bonus(workHours) + payroll.benefit(employee); 
      log.addBonuses (bonuses, employee);
      result = computeRegularPayAmount(employee, bonuses);
    }
  }
  return result;
}
