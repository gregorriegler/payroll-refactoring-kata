public class Employee {

    private final int rate;
    private final boolean separated;
    private final boolean retired;

    public Employee(int rate, boolean separated, boolean retired) {
        this.rate = rate;
        this.separated = separated;
        this.retired = retired;
    }

    public int getRate() {
        return rate;
    }

    public boolean isSeparated() {
        return separated;
    }

    public boolean isRetired() {
        return retired;
    }
}
