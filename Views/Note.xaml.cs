using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MauiApp1.Views;

[QueryProperty(nameof(ItemId),nameof(ItemId))]
public partial class Note : ContentPage
{
	public string ItemId
	{
		set
		{
			LoadNote(value);
		}
	}
    //string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.text");

	private void LoadNote(string fileName)
	{
		Models.Note noteModel = new Models.Note();
		noteModel.FileName = fileName;

		if (File.Exists(fileName))
		{
			noteModel.Date = File.GetCreationTime(fileName);
			noteModel.Text = File.ReadAllText(fileName);
		}
		BindingContext = noteModel;
		}
    public Note()
	{
		InitializeComponent();
		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
		LoadNote(Path.Combine(appDataPath,randomFileName));
	}

	private async void SaveButton_clicked(object sender, EventArgs e)
	{
		if(BindingContext is Models.Note note)
		File.WriteAllText(note.FileName, TextEditor.Text);

		await Shell.Current.GoToAsync("..");
	}

	private async void Delete_Button(object sender, EventArgs e)
	{
		if(BindingContext is Models.Note note)
		{
            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }
        }
		
		await Shell.Current.GoToAsync("..");
	}
}