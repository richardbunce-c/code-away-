using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given two Dictionaries, Dictionary<string, int>, merge the two into a new Dictionary, Dictionary<string, int> where keys in Dictionary2,
         * and their int values, are added to the int values of matching keys in Dictionary1. Return the new Dictionary.
         *
         * Unmatched keys and their int values in Dictionary2 are simply added to Dictionary1.
         *
         * ConsolidateInventory({"SKU1": 100, "SKU2": 53, "SKU3": 44} {"SKU2":11, "SKU4": 5})
         * 	 → {"SKU1": 100, "SKU2": 64, "SKU3": 44, "SKU4": 5}
         *
         */
        public Dictionary<string, int> ConsolidateInventory(Dictionary<string, int> mainWarehouse,
            Dictionary<string, int> remoteWarehouse)
        {

            //Setup a new, consolidatedWH dictionary
            Dictionary<string, int> consWarehouse = new Dictionary<string, int>(mainWarehouse);

            //Add everything from the mainWH to consolidatedWH
            //foreach(KeyValuePair<string, int> kvp in mainWarehouse)
            //    {
            //    consWarehouse[kvp.Key] = kvp.Value;
            //}
            //Loop thru remoteWH
            foreach (KeyValuePair<string, int> kvp in remoteWarehouse)
            {
                // if the sku in remoteWH already exists in consolidated, sum the inventories
                if (consWarehouse.ContainsKey(kvp.Key))
                {
                    consWarehouse[kvp.Key] += kvp.Value;
                }
                //Else(the sku in the remote does not yet exist in the consolidated), add the entire kvp from the remoteWH into the consolidatedWH
          //add the entire kvp from the remoteWH into the consolidatedWH
                else
                {
                    consWarehouse[kvp.Key] = kvp.Value;
                }
            }
            //Return the consolidatedWH

 return consWarehouse;
        }
    }
}
