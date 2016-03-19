using System;
using System.Collections.Generic;

namespace hack24.core.Model
{
    public class ProfileModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string JobTitle { get; set; }
        public string Bio { get; set; }
	    public string Department { get; set; }

        public Tag[] Tags { get; set; }

	    public ProfileModel()
	    {
		    this.Id = Guid.NewGuid();
	    }
    }
}