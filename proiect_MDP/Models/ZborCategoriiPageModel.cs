using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect_MDP.Data;
using proiect_MDP.Migrations;


namespace proiect_MDP.Models
{
    public class ZborCategoriiPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(proiect_MDPContext context, Zbor zbor)
        {
            var allCategories = context.Categorie;
            var zborCategorii = new HashSet<int>(zbor.ZborCategorii.Select(c => c.CategorieID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.CategorieName,
                    Assigned = zborCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(proiect_MDPContext context, string[] selectedCategories, Zbor bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.ZborCategorii = new List<ZborCategorie>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var zborCategorii = new HashSet<int>
            (bookToUpdate.ZborCategorii.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!zborCategorii.Contains(cat.ID))
                    {
                        bookToUpdate.ZborCategorii.Add(
                        new ZborCategorie
                        {
                            ZborID = bookToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (zborCategorii.Contains(cat.ID))
                    {
                        ZborCategorie courseToRemove
                        = bookToUpdate
                        .ZborCategorii
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
