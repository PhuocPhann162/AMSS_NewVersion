using System.Text.Json.Serialization;

namespace AMSS.Dto.Responses.Countries
{
    public class CountrySelectionResponse<T> : SelectionResponse<T>
    {
        public string PhoneCode { get; set; }

        public CountrySelectionResponse(T value, string name, string phoneCode) : base(value, name)
        {
            PhoneCode = phoneCode;
        }
    }

    public class SelectionResponse<T>
    {
        public SelectionResponse()
        {
        }

        public SelectionResponse(T value, string name)
        {
            Value = value;
            Name = name;
        }

        public T Value { get; set; }
        public string Name { get; set; }
    }
}
