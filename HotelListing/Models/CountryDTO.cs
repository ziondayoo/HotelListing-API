﻿using HotelListing.Data;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{

    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is too long")]
        public string Name { get; set; }

        [StringLength(maximumLength: 2, ErrorMessage = "Short Country Name is too long")]
        public string ShortName { get; set; }
    }
    public class UpdateCountryDTO : CreateHotelDTO
    { 
        public IList<CreateHotelDTO> Hotels { get; set; } 
    }

    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public virtual IList<HotelDTO> Hotels { get; set; }
    }
}
