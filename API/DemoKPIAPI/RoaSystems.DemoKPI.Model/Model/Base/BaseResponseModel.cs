namespace RoaSystems.DemoKPI.Model.Model.Base
{
    public partial class BaseResponseModel<T> : SuperBaseModel
    {
        public BaseResponseModel()
        {
            HasError = false;
        }
        /// <summary>
        /// Contains the result you want to return to the client
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Indicate if there is an error in the request or not
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Error details if HasError = true
        /// </summary>
        public ErrorDetailsModel ErrorDetails { get; set; }


    }
}
