public class PayrollApplication {

    private PayrollApplication() {
    }

    public static PayCheck payAmount(Employee employee, int workHours) {

        PayCheck result;
        if (!employee.isSeparated()) {
            if (employee.isRetired()) {
                result = new PayCheck(0, "RET");
            }
            else {
                // Logic to compute amount
                var bonus = computeBonus(workHours);
                var regularAmount = computeRegularPayAmount(employee, workHours);
                var amount = bonus + regularAmount;
                result = new PayCheck(amount, "EMP");
            }
        }
        else {
            result = new PayCheck(0, "SEP");
        }

        return result;
    }

    private static double computeBonus(int workHours) {
        return workHours > 40 ? 1000 : 0;
    }

    private static double computeRegularPayAmount(Employee employee, double workHours) {
        return employee.getRate() * workHours;
    }
}
