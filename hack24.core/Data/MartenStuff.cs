using Marten;

namespace hack24.core.Data
{
    public class MartenStuff
    {
	    private static DocumentStore _store;

	    public static DocumentStore Store
	    {
		    get
		    {
			    if (_store == null)
			    {
				    _store = DocumentStore.For("Server=localhost;Port=5432;Database=hack24;User Id=postgres;Password=password;");
			    }

			    return _store;
		    }
	    }
    }
}