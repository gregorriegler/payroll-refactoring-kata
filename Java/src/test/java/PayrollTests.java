import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

class PayrollTests {

    private static final int IRRELEVANT = 53;

    @Test
    void without_bonus() {
        var employee = new Employee(100, false, false);
        var payCheck  = PayrollApplication.payAmount(employee, 30);
        assertThat(payCheck).usingRecursiveComparison().isEqualTo(new PayCheck(3000, "EMP"));
    }

    @Test
    void with_bonus() {
        var employee = new Employee(10, false, false);
        var payCheck  = PayrollApplication.payAmount(employee, 41);
        assertThat(payCheck).usingRecursiveComparison().isEqualTo(new PayCheck(1410, "EMP"));
    }

    @Test
    void retired() {
        var employee = new Employee(IRRELEVANT, false, true);
        var payCheck  = PayrollApplication.payAmount(employee, IRRELEVANT);
        assertThat(payCheck).usingRecursiveComparison().isEqualTo(new PayCheck(0, "RET"));
    }

    @Test
    void separated() {
        var employee = new Employee(IRRELEVANT, true, false);
        var payCheck  = PayrollApplication.payAmount(employee, IRRELEVANT);
        assertThat(payCheck).usingRecursiveComparison().isEqualTo(new PayCheck(0, "SEP"));
    }
}
