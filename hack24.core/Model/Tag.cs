namespace hack24.core.Model
{
    public class Tag
    {
	    public string Prefix { get; set; }
	    public  int Id { get; set; }

	    public Tag(string name, string displayName, int id, string prefix)
	    {
		    this.Prefix = prefix;
		    this.Id = id;
		    this.Name = name;
		    this.DisplayName = displayName;
	    }

	    public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}