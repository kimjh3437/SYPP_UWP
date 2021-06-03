using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SYPP.Model.DB.Components.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.User
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string uID { get; set; }
        public string authID { get; set; }
        public User_Personal Personal { get; set; }
        public List<string> ApplicationIDs { get; set; }
        public List<string> TemplateIDs { get; set; }
        public List<string> CompanyIDs { get; set; }
        public List<Category> Preferences { get; set; }
        public string Token { get; set; }
    }
}
