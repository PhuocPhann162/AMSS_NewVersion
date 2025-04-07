using System.ComponentModel.DataAnnotations;

namespace AMSS.Dto.Requests.Suppliers
{
    public class CreateSupplierRequest
    {
        [Required(ErrorMessage = "Supplier Name is required.")]
        public string Name { get; set;}

        [Required(ErrorMessage = "Supplier Contact Name is required.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Supplier Phone Code is required.")]
        public string PhoneCode{ get; set; }

        [Required(ErrorMessage = "Supplier Phone Number is required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Supplier Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Supplier Address is required.")]
        public string Address { get; set; }
    }
}
