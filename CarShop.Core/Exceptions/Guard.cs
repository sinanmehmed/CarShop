namespace CarShop.Core.Exceptions
{
    public class Guard : IGuard
    {
        public void AgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ?
                    new CarShopExceptions() :
                    new CarShopExceptions(errorMessage);

                throw exception;
            }
        }
    }
}
