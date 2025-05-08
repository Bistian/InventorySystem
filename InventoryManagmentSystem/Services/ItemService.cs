using InventoryManagmentSystem.Database;
using InventoryManagmentSystem.Database.Entities;
using InventoryManagmentSystem.Database.Types;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace InventoryManagmentSystem.Services
{
    public class ItemService
    {
        private readonly AppDbContext _database;

        private class ItemGridDto
        {
            public Guid Id
            {
                get; set;
            }
            public string Type
            {
                get; set;
            }
            public string SerialNumber
            {
                get; set;
            }
            public string Brand
            {
                get; set;
            }
            public string Size
            {
                get; set;
            }
            public DateTime ManufacturedAt
            {
                get; set;
            }
            public string Condition
            {
                get; set;
            }
            public Guid? IdClient
            {
                get; set;
            }
            public string ClientName
            {
                get; set;
            }
            public string Material
            {
                get; set;
            }
            public string Color
            {
                get; set;
            }
        }

        public ItemService(AppDbContext database)
        {
            this._database = database;
        }

        public Item2 Add(Guid idBrand, string serialNumber, string type, string condition, string businessModel, DateTime manufacturedAt)
        {
            var item = new Item2();
            item.Id = Guid.NewGuid();
            item.IdBrand = idBrand; 
            item.SerialNumber = serialNumber; 
            item.Type = type;
            item.Condition = condition;
            item.BusinessModel = businessModel;
            item.ManufacturedAt = manufacturedAt;
            _database.Items.Add(item);
            _database.SaveChanges();
            return item;
        }

        public void AddBoots(Guid itemId, decimal size, string material)
        {
            var item = FindById(itemId);
            if(item == null)
            {
                Console.WriteLine("Id does not belong to any item");
                return;
            }
            var boots = new Boots();
            boots.Id = itemId;
            boots.Size = size;
            boots.Material = material;
            _database.Boots.Add(boots);
            _database.SaveChanges();
        }

        public void AddHelmet(Guid itemId, string color)
        {
            var item = FindById(itemId);
            if (item == null)
            {
                Console.WriteLine("Id does not belong to any item");
                return;
            }
            var helmet = new Helmet();
            helmet.Id = itemId;
            helmet.Color = color;
            _database.Helmets.Add(helmet);
            _database.SaveChanges();
        }

        public void AddJacket(Guid itemId, string size)
        {
            var item = FindById(itemId);
            if (item == null)
            {
                Console.WriteLine("Id does not belong to any item");
                return;
            }
            var jacket = new Jacket();
            jacket.Id = itemId;
            jacket.Size = size;
            _database.Jackets.Add(jacket);
            _database.SaveChanges();
        }

        public void AddMask(Guid itemId, string size)
        {
            var item = FindById(itemId);
            if (item == null)
            {
                Console.WriteLine("Id does not belong to any item");
                return;
            }
            var mask = new Mask();
            mask.Id = itemId;
            mask.Size = size;
            _database.Masks.Add(mask);
            _database.SaveChanges();
        }

        public void AddPants(Guid itemId, string size)
        {
            var item = FindById(itemId);
            if (item == null)
            {
                Console.WriteLine("Id does not belong to any item");
                return;
            }
            var pants = new Pants();
            pants.Id = itemId;
            pants.Size = size;
            _database.Pants.Add(pants);
            _database.SaveChanges();
        }

        public bool Update(ItemFull item)
        {
            var i = new Item2
            {
                Id = item.Id,
                IdBrand = item.IdBrand,
                IdClient = item.IdClient,
                BusinessModel = item.BusinessModel,
                Condition = item.Condition,
                DueDate = item.DueDate,
                ManufacturedAt = item.ManufacturedAt,
                SerialNumber = item.SerialNumber,
                Type = item.Type,
                UpdatedAt = new DateTime(),
            };

            try
            {
                switch (i.Type)
                {
                    case ItemTypes.Boots:
                        {
                            var size = double.Parse(item.Size);
                            if (double.IsNaN(size))
                            {
                                Console.WriteLine("Size was NaN, cannot update boots.");
                                break;
                            }

                            var b = new Boots
                            {
                                Id = item.Id,
                                Size = decimal.Parse(item.Size),
                                Material = item.Material,
                                UpdatedAt = new DateTime(),
                            };
                            _database.Entry(i).State = EntityState.Modified;
                            _database.Entry(b).State = EntityState.Modified;
                            _database.SaveChanges();
                            break;
                        }
                    case ItemTypes.Helmet:
                        {
                            var h = new Helmet
                            {
                                Id = item.Id,
                                Color = item.Color,
                                UpdatedAt = new DateTime(),
                            };
                            _database.Entry(i).State = EntityState.Modified;
                            _database.Entry(h).State = EntityState.Modified;
                            _database.SaveChanges();
                            break;
                        }
                    case ItemTypes.Jacket:
                    {
                        var j = new Jacket
                        {
                            Id = item.Id,
                            Size = item.Size,
                            UpdatedAt = new DateTime(),
                        };
                        _database.Entry(i).State = EntityState.Modified;
                        _database.Entry(j).State = EntityState.Modified;
                        _database.SaveChanges();
                        break;
                    }
                    case ItemTypes.Mask:
                        {
                            var m = new Mask
                            {
                                Id = item.Id,
                                Size = item.Size,
                                UpdatedAt = new DateTime(),
                            };
                            _database.Entry(i).State = EntityState.Modified;
                            _database.Entry(m).State = EntityState.Modified;
                            _database.SaveChanges();
                            break;
                        }
                    case ItemTypes.Pants:
                        {
                            var p = new Pants
                            {
                                Id = item.Id,
                                Size = item.Size,
                                UpdatedAt = new DateTime(),
                            };
                            _database.Entry(i).State = EntityState.Modified;
                            _database.Entry(p).State = EntityState.Modified;
                            _database.SaveChanges();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Could not find item type to update.");
                            return false;
                        }
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        
        public bool Delete(Guid itemId, string itemType)
        {
            try
            {
                switch (itemType)
                {
                    case ItemTypes.Boots:
                        {
                            _database.Entry(new Boots() { Id = itemId }).State = EntityState.Deleted;
                            break;
                        }
                    case ItemTypes.Helmet:
                        {
                            _database.Entry(new Helmet() { Id = itemId }).State = EntityState.Deleted;
                            break;
                        }
                    case ItemTypes.Jacket:
                        {
                            _database.Entry(new Jacket() { Id = itemId }).State = EntityState.Deleted;
                            break;
                        }
                    case ItemTypes.Mask:
                        {
                            _database.Entry(new Mask() { Id = itemId }).State = EntityState.Deleted;
                            break;
                        }
                    case ItemTypes.Pants:
                        {
                            _database.Entry(new Pants() { Id = itemId }).State = EntityState.Deleted;
                            break;
                        }
                    default: return false;
                }
                _database.Entry(new Item2() { Id = itemId}).State = EntityState.Deleted;
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool DeleteBoots(Guid itemId)
        {
            try
            {
                var boots = _database.Boots.FirstOrDefault(b => b.Id == itemId);
                _database.Boots.Remove(boots);
                _database.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<Item2> FindAll()
        {
            try
            {
                var list = _database.Items.ToList();
                if (list.Count > 0)
                {
                    return list;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<ItemType> FindAllItemTypes()
        {
            try
            {
                var list = _database.ItemTypes.ToList();
                if (list.Count > 0)
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public List<ItemFull> FindByClientId(Guid clientId)
        {
            try
            {
                var rows = (
                    from i in _database.Items
                    where i.IdClient == clientId

                    // LEFT JOIN tbBoots AS b ON i.Id = b.Id
                    join b0 in _database.Boots on i.Id equals b0.Id into bs
                    from b in bs.DefaultIfEmpty()

                        // LEFT JOIN tbHelmets AS h ON i.Id = h.Id
                    join h0 in _database.Helmets on i.Id equals h0.Id into hs
                    from h in hs.DefaultIfEmpty()

                        // LEFT JOIN tbJackets AS j ON i.Id = j.Id
                    join j0 in _database.Jackets on i.Id equals j0.Id into js
                    from j in js.DefaultIfEmpty()

                        // LEFT JOIN tbMasks AS p ON i.Id = p.Id
                    join m0 in _database.Masks on i.Id equals m0.Id into ms
                    from m in ms.DefaultIfEmpty()

                        // LEFT JOIN tbPants AS p ON i.Id = p.Id
                    join p0 in _database.Pants on i.Id equals p0.Id into ps
                    from p in ps.DefaultIfEmpty()

                    select new ItemFull
                    {
                        Id = i.Id,
                        IdBrand = i.IdBrand,
                        IdClient = i.IdClient,
                        SerialNumber = i.SerialNumber,
                        Type = i.Type,
                        Brand = i.Brand.Name,
                        Condition = i.Condition,
                        BusinessModel = i.BusinessModel,
                        DueDate = i.DueDate ?? null,
                        ManufacturedAt = i.ManufacturedAt,

                        // we coalesce size from whichever complement exists
                        Size = b != null ? b.Size.ToString()
                                          : j != null ? j.Size.ToString()
                                          : p != null ? p.Size.ToString()
                                          : m != null ? m.Size.ToString()
                                          : null,

                        // only boots have Material
                        Material = (b != null) ? b.Material : null,
                        // only helmets have Color
                        Color = (h != null) ? h.Color : null,
                    }).ToList();

                if(rows.Count > 0)
                {
                    return rows;
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<ItemFull> FindByDueDate(DateTime dueDate)
        {
            try
            {
                var rows = (
                    from i in _database.Items
                    where i.DueDate == dueDate

                    // LEFT JOIN tbBoots AS b ON i.Id = b.Id
                    join b0 in _database.Boots on i.Id equals b0.Id into bs
                    from b in bs.DefaultIfEmpty()

                        // LEFT JOIN tbHelmets AS h ON i.Id = h.Id
                    join h0 in _database.Helmets on i.Id equals h0.Id into hs
                    from h in hs.DefaultIfEmpty()

                        // LEFT JOIN tbJackets AS j ON i.Id = j.Id
                    join j0 in _database.Jackets on i.Id equals j0.Id into js
                    from j in js.DefaultIfEmpty()

                        // LEFT JOIN tbMasks AS p ON i.Id = p.Id
                    join m0 in _database.Masks on i.Id equals m0.Id into ms
                    from m in ms.DefaultIfEmpty()

                        // LEFT JOIN tbPants AS p ON i.Id = p.Id
                    join p0 in _database.Pants on i.Id equals p0.Id into ps
                    from p in ps.DefaultIfEmpty()

                    select new ItemFull
                    {
                        Id = i.Id,
                        IdBrand = i.IdBrand,
                        IdClient = i.IdClient,
                        SerialNumber = i.SerialNumber,
                        Type = i.Type,
                        Brand = i.Brand.Name,
                        Condition = i.Condition,
                        BusinessModel = i.BusinessModel,
                        DueDate = i.DueDate ?? null,
                        ManufacturedAt = i.ManufacturedAt,

                        // we coalesce size from whichever complement exists
                        Size = b != null ? b.Size.ToString()
                                          : j != null ? j.Size.ToString()
                                          : p != null ? p.Size.ToString()
                                          : m != null ? m.Size.ToString()
                                          : null,

                        // only boots have Material
                        Material = (b != null) ? b.Material : null,
                        // only helmets have Color
                        Color = (h != null) ? h.Color : null,
                    }).ToList();

                if (rows.Count > 0)
                {
                    return rows;
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public ItemFull FindById(Guid id)
        {
            try
            {
                var row = (
                     from i in _database.Items
                     where i.Id == id

                     // LEFT JOIN tbBoots AS b ON i.Id = b.Id
                     join b0 in _database.Boots on i.Id equals b0.Id into bs
                     from b in bs.DefaultIfEmpty()

                         // LEFT JOIN tbHelmets AS h ON i.Id = h.Id
                     join h0 in _database.Helmets on i.Id equals h0.Id into hs
                     from h in hs.DefaultIfEmpty()

                         // LEFT JOIN tbJackets AS j ON i.Id = j.Id
                     join j0 in _database.Jackets on i.Id equals j0.Id into js
                     from j in js.DefaultIfEmpty()

                         // LEFT JOIN tbMasks AS p ON i.Id = p.Id
                     join m0 in _database.Masks on i.Id equals m0.Id into ms
                     from m in ms.DefaultIfEmpty()

                         // LEFT JOIN tbPants AS p ON i.Id = p.Id
                     join p0 in _database.Pants on i.Id equals p0.Id into ps
                     from p in ps.DefaultIfEmpty()

                     select new ItemFull
                     {
                         Id = i.Id,
                         IdBrand = i.IdBrand,
                         IdClient = i.IdClient,
                         SerialNumber = i.SerialNumber,
                         Type = i.Type,
                         Brand = i.Brand.Name,
                         Condition = i.Condition,
                         BusinessModel = i.BusinessModel,
                         DueDate = i.DueDate ?? null,
                         ManufacturedAt = i.ManufacturedAt,

                         // we coalesce size from whichever complement exists
                         Size = b != null ? b.Size.ToString()
                                           : j != null ? j.Size.ToString()
                                           : p != null ? p.Size.ToString()
                                           : m != null ? m.Size.ToString()
                                           : null,

                         // only boots have Material
                         Material = (b != null) ? b.Material : null,
                         // only helmets have Color
                         Color = (h != null) ? h.Color : null,
                     }).FirstOrDefault();

                return row;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<ItemFull> FindBySearchBar(string serchTerm)
        {
            try
            {
                var rows = (
                    from i in _database.Items
                    where i.IdClient == null &&
                        i.SerialNumber.Contains(serchTerm) &&
                        i.Condition != ItemConditions.Retired

                    // LEFT JOIN tbBoots AS b ON i.Id = b.Id
                    join b0 in _database.Boots on i.Id equals b0.Id into bs
                    from b in bs.DefaultIfEmpty()

                        // LEFT JOIN tbHelmets AS h ON i.Id = h.Id
                    join h0 in _database.Helmets on i.Id equals h0.Id into hs
                    from h in hs.DefaultIfEmpty()

                        // LEFT JOIN tbJackets AS j ON i.Id = j.Id
                    join j0 in _database.Jackets on i.Id equals j0.Id into js
                    from j in js.DefaultIfEmpty()

                        // LEFT JOIN tbMasks AS p ON i.Id = p.Id
                    join m0 in _database.Masks on i.Id equals m0.Id into ms
                    from m in ms.DefaultIfEmpty()

                        // LEFT JOIN tbPants AS p ON i.Id = p.Id
                    join p0 in _database.Pants on i.Id equals p0.Id into ps
                    from p in ps.DefaultIfEmpty()

                    select new ItemFull
                    {
                        Id = i.Id,
                        IdBrand = i.IdBrand,
                        IdClient = i.IdClient,
                        SerialNumber = i.SerialNumber,
                        Type = i.Type,
                        Brand = i.Brand.Name,
                        Condition = i.Condition,
                        BusinessModel = i.BusinessModel,
                        DueDate = i.DueDate ?? null,
                        ManufacturedAt = i.ManufacturedAt,

                        // we coalesce size from whichever complement exists
                        Size = b != null ? b.Size.ToString()
                                          : j != null ? j.Size.ToString()
                                          : p != null ? p.Size.ToString()
                                          : m != null ? m.Size.ToString()
                                          : null,

                        // only boots have Material
                        Material = (b != null) ? b.Material : null,
                        // only helmets have Color
                        Color = (h != null) ? h.Color : null,
                    }).ToList();

                if (rows.Count > 0)
                {
                    return rows;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public ItemFull FindBySerialNumber(string itemType, string serialNumber)
        {
            try
            {
                var row = (
                    from i in _database.Items
                    where i.SerialNumber == serialNumber &&
                        i.Type == itemType

                    // LEFT JOIN tbBoots AS b ON i.Id = b.Id
                    join b0 in _database.Boots on i.Id equals b0.Id into bs
                    from b in bs.DefaultIfEmpty()

                        // LEFT JOIN tbHelmets AS h ON i.Id = h.Id
                    join h0 in _database.Helmets on i.Id equals h0.Id into hs
                    from h in hs.DefaultIfEmpty()

                        // LEFT JOIN tbJackets AS j ON i.Id = j.Id
                    join j0 in _database.Jackets on i.Id equals j0.Id into js
                    from j in js.DefaultIfEmpty()

                        // LEFT JOIN tbMasks AS p ON i.Id = p.Id
                    join m0 in _database.Masks on i.Id equals m0.Id into ms
                    from m in ms.DefaultIfEmpty()

                        // LEFT JOIN tbPants AS p ON i.Id = p.Id
                    join p0 in _database.Pants on i.Id equals p0.Id into ps
                    from p in ps.DefaultIfEmpty()

                    select new ItemFull
                    {
                        Id = i.Id,
                        IdBrand = i.IdBrand,
                        IdClient = i.IdClient,
                        SerialNumber = i.SerialNumber,
                        Type = i.Type,
                        Brand = i.Brand.Name,
                        Condition = i.Condition,
                        BusinessModel = i.BusinessModel,
                        DueDate = i.DueDate ?? null,
                        ManufacturedAt = i.ManufacturedAt,

                        // we coalesce size from whichever complement exists
                        Size = b != null ? b.Size.ToString()
                                          : j != null ? j.Size.ToString()
                                          : p != null ? p.Size.ToString()
                                          : m != null ? m.Size.ToString()
                                          : null,

                        // only boots have Material
                        Material = (b != null) ? b.Material : null,
                        // only helmets have Color
                        Color = (h != null) ? h.Color : null,
                    }).FirstOrDefault();

                return row;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<ItemFull> FindWhere(Expression<Func<Item2, bool>> condition)
        {
            try
            {
                var rows = (
                    from i in _database.Items.Where(condition)

                    // LEFT JOIN tbBoots AS b ON i.Id = b.Id
                    join b0 in _database.Boots on i.Id equals b0.Id into bs
                    from b in bs.DefaultIfEmpty()

                        // LEFT JOIN tbHelmets AS h ON i.Id = h.Id
                    join h0 in _database.Helmets on i.Id equals h0.Id into hs
                    from h in hs.DefaultIfEmpty()

                        // LEFT JOIN tbJackets AS j ON i.Id = j.Id
                    join j0 in _database.Jackets on i.Id equals j0.Id into js
                    from j in js.DefaultIfEmpty()

                        // LEFT JOIN tbMasks AS p ON i.Id = p.Id
                    join m0 in _database.Masks on i.Id equals m0.Id into ms
                    from m in ms.DefaultIfEmpty()

                        // LEFT JOIN tbPants AS p ON i.Id = p.Id
                    join p0 in _database.Pants on i.Id equals p0.Id into ps
                    from p in ps.DefaultIfEmpty()

                    select new ItemFull
                    {
                        Id = i.Id,
                        IdBrand = i.IdBrand,
                        IdClient = i.IdClient,
                        SerialNumber = i.SerialNumber,
                        Type = i.Type,
                        Brand = i.Brand.Name,
                        Condition = i.Condition,
                        BusinessModel = i.BusinessModel,
                        DueDate = i.DueDate ?? null,
                        ManufacturedAt = i.ManufacturedAt,

                        // we coalesce size from whichever complement exists
                        Size = b != null ? b.Size.ToString()
                                          : j != null ? j.Size.ToString()
                                          : p != null ? p.Size.ToString()
                                          : m != null ? m.Size.ToString()
                                          : null,

                        // only boots have Material
                        Material = (b != null) ? b.Material : null,
                        // only helmets have Color
                        Color = (h != null) ? h.Color : null,
                    }).ToList();

                if (rows.Count > 0)
                {
                    return rows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void LoadDataGrid(DataGridView grid)
        {
            var rows = (
                from i in _database.Items

                    // Boots: i.Id == b.Id
                join b0 in _database.Boots
                    on i.Id equals b0.Id into bs
                from b in bs.DefaultIfEmpty()

                    // Helmets: i.Id == h.Id
                join h0 in _database.Helmets
                    on i.Id equals h0.Id into hs
                from h in hs.DefaultIfEmpty()

                    // Jackets: i.Id == j.Id
                join j0 in _database.Jackets
                    on i.Id equals j0.Id into js
                from j in js.DefaultIfEmpty()

                    // Masks: i.Id == p.Id
                join m0 in _database.Masks
                    on i.Id equals m0.Id into ms
                from m in ms.DefaultIfEmpty()

                    // Pants: i.Id == p.Id
                join p0 in _database.Pants
                    on i.Id equals p0.Id into ps
                from p in ps.DefaultIfEmpty()

                    // Brands: use the FK on Items
                join br0 in _database.Brands
                    on i.IdBrand equals br0.Id into brs
                from br in brs.DefaultIfEmpty()

                    // Clients: same as before
                join c0 in _database.Clients
                    on i.IdClient equals c0.Id into cs
                from c in cs.DefaultIfEmpty()

                select new ItemGridDto
                {
                    Id = i.Id,
                    Type = i.Type,
                    SerialNumber = i.SerialNumber,

                    // Brand comes straight from the Items→Brands join:
                    Brand = br.Name,

                    // Size coalesces only from those complements that have it:
                    Size =(b == null ? null : b.Size.ToString())
                        ?? (j == null ? null : j.Size.ToString())
                        ?? (p == null ? null : p.Size.ToString())
                        ?? (m == null ? null : m.Size.ToString()),

                    ManufacturedAt = i.ManufacturedAt,
                    Condition = i.Condition,
                    IdClient = i.IdClient,
                    ClientName = c.Name,

                    // Complement-specific fields:
                    Material = b.Material,
                    Color = h.Color
                }
            ).ToList();

            try
            {
                int index = 0;
                foreach (var r in rows)
                {
                    grid.Rows.Add(
                        ++index,
                        r.Id,
                        r.Size,
                        r.Material,
                        r.Color,
                        r.Brand,
                        r.Condition,
                        r.SerialNumber,
                        "Acquisition Date",
                        r.ManufacturedAt,
                        r.IdClient,
                        r.Type,
                        r.ClientName
                    );
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public void LoadComboBoxWithItemTypes(ComboBox comboBox)
        {
            var list = FindAllItemTypes();
            if (list == null) { return; }

            foreach (var i in list)
            {
                comboBox.Items.Add(i.Type);
            }
        }

        public int RentCount(string itemType = null)
        {
            try
            {
                if(itemType == null)
                {
                    return _database.Items.Count(i =>
                        i.IdClient != null &&
                        i.Condition != ItemConditions.Retired
                    );
                }

                return _database.Items.Count(i =>
                    i.IdClient != null &&
                    i.Condition != ItemConditions.Retired &&
                    i.Type == itemType
                );
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public void Rent(Guid itemId, Guid clientId, DateTime dueDate)
        {
            try
            {
                var item = FindById(itemId);
                item.IdClient = clientId;
                item.DueDate = dueDate;
                _database.Entry(item).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void Return(Guid itemId)
        {
            try
            {
                var item = FindById(itemId);
                if(item == null)
                {
                    Console.WriteLine("Could not find item.");
                    return;
                }
                item.IdClient = null;
                item.DueDate = null;
                _database.Entry(item).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch( Exception ex )
            {
                Console.Write(ex.Message);
            }
        }

        public int StockCount(string itemType = null)
        {
            try
            {
                if (itemType == null)
                {
                    return _database.Items.Count(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired
                    );
                }

                return _database.Items.Count(i =>
                    i.IdClient == null &&
                    i.Condition != ItemConditions.Retired &&
                    i.Type == itemType
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public int AvailableCount(string itemType = null)
        {
            try
            {
                if (itemType == null)
                {
                    return _database.Items.Count(i =>
                        i.IdClient == null &&
                        i.Condition != ItemConditions.Retired
                    );
                }

                return _database.Items.Count(i =>
                    i.IdClient == null &&
                    i.Condition != ItemConditions.Retired &&
                    i.Type == itemType
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
