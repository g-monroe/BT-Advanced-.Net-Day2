using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero
{
    public class UniverseManager
    {
        public static Boolean UniExists(int id)
        {
            var uni = WebApiAssignment.Datastore.UniverseHandler.GetUniverse(id);
            if (uni == null)
            {
                return false;
            }
            return true;
        }
        public static WebApiAssignment.Datastore.DataModels.Universe setupUni(RequestObjects.UniverseCreationRequest request, WebApiAssignment.Datastore.DataModels.Universe uni)
        {
            uni.UniverseName = request.UniverseName;
            uni.Id = request.Id;
            uni.ParentCompany = request.ParentCompany;
            return uni;
        }
    }
}
