namespace hack24.core.Model
{
    public class Tag
    {
	    public  int Id { get; set; }

	    public Tag(string name, string displayName, int id)
	    {
		    this.Id = id;
		    this.Name = name;
		    this.DisplayName = displayName;
	    }

	    public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}