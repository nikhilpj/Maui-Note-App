using System.Security.Cryptography.X509Certificates;

namespace MauiApp1.Views;

public partial class Note : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.text");

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

	private void SaveButton_clicked(object sender, EventArgs e)
	{
		File.WriteAllText(_fileName, TextEditor.Text);
	}

	private void Delete_Button(object sender, EventArgs e)
	{
		if(File.Exists(_fileName))
		{
			File.Delete(_fileName);
		}
		TextEditor.Text = string.Empty;
	}
}