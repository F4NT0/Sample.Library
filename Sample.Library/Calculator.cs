namespace Sample.Library
{
    public class Calculator : AbstractCalculator
    {
        public override void ReleaseResources()
        {
            
        }

        public override int sum(int a, int b) { return a + b; }
    }
}