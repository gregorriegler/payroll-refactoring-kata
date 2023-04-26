using NUnit.Framework;
using PayRoll;

namespace PayRollTest;

public class PayRollTests
{
    private const int IRRELEVANT = 53;

    [Test]
    public void without_bonus()
    {
        var employee = new Employee(100, false, false);
        
        var payCheck  = PayRollApplication.PayAmount(employee, 30);
        
        Assert.AreEqual(new PayCheck(3000, "EMP"), payCheck);
    }
    
    [Test]
    public void with_bonus()
    {
        var employee = new Employee(10, false, false);
        
        var payCheck  = PayRollApplication.PayAmount(employee, 41);
        
        Assert.AreEqual(new PayCheck(1410, "EMP"), payCheck);
    }
    
    [Test]
    public void retired()
    {
        var employee = new Employee(IRRELEVANT, false, true);
        
        var payCheck  = PayRollApplication.PayAmount(employee, IRRELEVANT);
        
        Assert.AreEqual(new PayCheck(0, "RET"), payCheck);
    }
    
    [Test]
    public void separated()
    {
        var employee = new Employee(IRRELEVANT, true, false);
        
        var payCheck  = PayRollApplication.PayAmount(employee, IRRELEVANT);
        
        Assert.AreEqual(new PayCheck(0, "SEP"), payCheck);
    }
}