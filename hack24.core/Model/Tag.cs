namespace hack24.core.Model
{
    public class Tag
    {
	    public Tag(string name, string displayName)
	    {
		    this.Name = name;
		    this.DisplayName = displayName;
	    }

	    public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}