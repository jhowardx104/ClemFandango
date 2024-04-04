using ClemFandango.Common.CouchDb.Documents;
using CouchDB.Driver;
using CouchDB.Driver.Options;

namespace ClemFandango.Common.CouchDb;

public class ClemFandangoCouchDbContext: CouchContext
{
    public CouchDatabase<InsultDictionary> Insults { get; set; }
    
    
}