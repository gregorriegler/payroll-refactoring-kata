namespace PayRoll;

public static class PayRollApplication
{
    public static PayCheck PayAmount(Employee employee, int workHours)
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

    private static decimal ComputeRegularPayAmount(Employee employee, decimal workHours)
    {
        return employee.Rate * workHours;
    }
}

public class Employee
{
    public int Rate { get; }
    private readonly bool _separated;
    private readonly bool _retired;

    public Employee(int rate, bool separated, bool retired)
    {
        Rate = rate;
        _separated = separated;
        _retired = retired;
    }

    public bool IsSeparated()
    {
        return _separated;
    }

    public bool IsRetired()
    {
        return _retired;
    }
}

public class PayCheck
{
    private decimal Amount { get; }
    private string ReasonCode { get; }

    public PayCheck(decimal amount, string reasonCode)
    {
        Amount = amount;
        ReasonCode = reasonCode;
    }

    public override string ToString()
    {
        return ReasonCode + " " + Amount;
    }

    private bool Equals(PayCheck other)
    {
        return Amount == other.Amount && ReasonCode == other.ReasonCode;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((PayCheck)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, ReasonCode);
    }
}