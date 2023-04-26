namespace PayRoll;

public class PayRollApplication
{
    public PayCheck PayAmount(Employee employee, int workHours)
    {
        PayCheck result;
        if (!employee.IsSeparated())
        {
            if (employee.IsRetired())
            {
                result = new PayCheck(0, "RET");
            }
            else
            {
                // logic to compute amount
                employee.PayCheckGenerated(DateTime.Today);
                var bonus = ComputeBonus(employee, workHours);
                var regularAmount = ComputeRegularPayAmount(employee, workHours);
                var amount = bonus + regularAmount;
                result = new PayCheck(amount, "EMP");
            }
        }
        else
        {
            result = new PayCheck(0, "SEP");
        }

        return result;
    }

    private static decimal ComputeBonus(Employee employee, int workHours)
    {
        return workHours > 40 ? 1000 : 0;
    }

    private static decimal ComputeRegularPayAmount(Employee employee, decimal bonus)
    {
        return 500;
    }
}

public class Employee
{
    private int id;
    private int rate;
    private bool separated;
    private bool retired;
    private DateTime paidAt;

    public Employee(int id, int rate, bool separated, bool retired, DateTime paidAt)
    {
        this.id = id;
        this.rate = rate;
        this.separated = separated;
        this.retired = retired;
        this.paidAt = paidAt;
    }

    public bool IsSeparated()
    {
        return separated;
    }

    public bool IsRetired()
    {
        return retired;
    }

    public void PayCheckGenerated(DateTime dateTime)
    {
        paidAt = dateTime;
    }
}

public class PayCheck
{
    public decimal Amount { get; }
    public string ReasonCode { get; }

    public PayCheck(decimal amount, string reasonCode)
    {
        Amount = amount;
        ReasonCode = reasonCode;
    }
}