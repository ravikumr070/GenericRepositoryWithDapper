using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Country
{
    public class Country
    {
        public long CountryID { get; set; }

        public string CountryName { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsClosed { get; set; }

        public string ModifyBy { get; set; }

        public string Code { get; set; }

    }
}
