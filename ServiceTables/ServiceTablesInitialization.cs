using ServiceAccess;
using ServiceAccess.Model;

namespace ServiceTables
{
    public class ServiceTablesInitialization
    {
        
        public static bool Initializated { get; set; }
        public static void UploadTableDataBase()
        {
            var initializeList = new DataBaseOfList();
            if (!Initializated)
            {
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 1, TableId = "T1C2", TableCategory = AvailableTables.TableFor2Peoples, Capacity = 2 });
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 2, TableId = "T2C2", TableCategory = AvailableTables.TableFor2Peoples, Capacity = 2 });
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 3, TableId = "T3C4", TableCategory = AvailableTables.TableFor4Peoples, Capacity = 4 });
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 4, TableId = "T4C4", TableCategory = AvailableTables.TableFor4Peoples, Capacity = 4 });
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 5, TableId = "T5C4", TableCategory = AvailableTables.TableFor4Peoples, Capacity = 4 });
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 6, TableId = "T6C4", TableCategory = AvailableTables.TableFor4Peoples, Capacity = 4 });
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 7, TableId = "T7C6", TableCategory = AvailableTables.TableFor6Peoples, Capacity = 6 });
                DataBaseOfList.TableDbList.Add(new Tables() { Id = 8, TableId = "T8C8", TableCategory = AvailableTables.TableFor8Peoples, Capacity = 8 });
                Initializated = true;
            }

            
        }
    }
}