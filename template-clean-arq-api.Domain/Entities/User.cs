namespace template_clean_arq_api.Domain.Entities
{
    public partial class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string CountryId { get; set; }

        public string StatusId { get; set; }

        public static User Create(string name, string email, string password, string phoneNumber, string countryId, string statusId)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                CountryId = countryId,
                StatusId = statusId
            };
        }
    }
}
