using BrightIdeasSoftware;
using System.Diagnostics;
using System.Text.Json;
using static Müller_Studio.Program;

namespace Müller_Studio
{
    public partial class Form1 : Form
    {
        string? _loadedProjectName;
        string? _loadedProjectPath;
        List<MulObject>? _loadedProject;
        public Form1()
        {
            ValidateFileSystem();
            InitializeComponent();
            OLVColumn mulNameColumn = new OLVColumn("Name", "Name");
            OLVColumn repeatColumn = new OLVColumn("Repeat(X)", "Repeat");
            //OLVColumn deleteColumn = new OLVColumn();
            //mulListView.UseHotItem = false;
            //mulListView.UseTranslucentHotItem = true;
            //deleteColumn.Text = "Delete";
            //deleteColumn.Width = 80;
            //deleteColumn.IsEditable = false;
            //deleteColumn.IsButton = true;
            //deleteColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            //deleteColumn.ButtonSize = new Size(80, 26);

            mulNameColumn.Width = 380;
            mulNameColumn.IsEditable = false;
            repeatColumn.Width = 80;
            repeatColumn.IsEditable = true;
            mulListView.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;

            //mulListView.CellEditStarting += MulListView_CellEditStarting;
            mulListView.CellEditFinishing += MulListView_CellEditFinishing;
            mulListView.CellEditFinished += MulListView_CellEditFinished;
            mulListView.Columns.Add(mulNameColumn);
            mulListView.Columns.Add(repeatColumn);
           // mulListView.Columns.Add(deleteColumn);
            LoadProjects();
        }

        private void MulListView_CellEditFinished(object sender, CellEditEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(_loadedProject);
            File.WriteAllText(_loadedProjectPath + _loadedProjectName + ".mulstu", jsonString);
        }

        private void MulListView_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if ((int)e.NewValue < 0)
            { 
                e.Cancel = true;
                MessageBox.Show(this, "You can only enter positive numbers", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ((ObjectListView)sender).RefreshItem(e.ListViewItem);
            }
        }

        private void MulListView_CellEditStarting(object sender, CellEditEventArgs e)
        {
            ////e.Column.AspectName gives the model column name of the editing column
            //if (e.Column.AspectName == "Repeat")
            //    if (e.Value is int)
            //    {
            //        NumericUpDown nud = new NumericUpDown();
            //        nud.Bounds = e.CellBounds;
            //        nud.Minimum = 0;
            //        nud.Maximum = 999;
            //        nud.Value = (int)e.Value;
            //        e.Control = nud;
            //        e.NewValue = (int)nud.Value;
            //        //((ObjectListView)sender).RefreshItem(e.ListViewItem);
            //        //mulListView.RefreshObjects(_loadedProject
            //    }
        }

        private void LoadProjects()
        {
            projectListbox.Items.Clear();
            var projects = Directory.GetDirectories(ProjectFolder).Select(d => new DirectoryInfo(d).Name).ToArray();
            projectListbox.Items.AddRange(projects);
        }

        private void LoadProject(string projectName)
        {
            _loadedProjectName = projectName;
            _loadedProjectPath = Path.Combine(ProjectFolder, projectName) + @"\";
            string jsonString = File.ReadAllText(Path.Combine(_loadedProjectPath, projectName + ".mulstu"));
            try
            {
                _loadedProject = JsonSerializer.Deserialize<List<MulObject>>(jsonString);
            }
            catch (Exception)
            {
                _loadedProject = new List<MulObject>();
            }
            
            mulListView.SetObjects(_loadedProject);
            Text = $"Müller Studio - Loaded Project: {projectName}";
            buildBtn.Enabled = true;
            addMulBtn.Enabled = true;
        }

        private void addMulBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Müller Replays|*.mul"//,
                //InitialDirectory = Directory.GetCurrentDirectory()
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Random rand = new Random();
                int filenumber = rand.Next(10000, 99999);
                while (File.Exists(@$"{_loadedProjectPath}Resources\{filenumber}.mul"))
                {
                    filenumber = rand.Next(10000, 99999);
                }
                
                string filename = $"res{filenumber}.mul";
                string path = @$"{_loadedProjectPath}Resources\{filename}";
                
                File.Copy(ofd.FileName, path, true);

                _loadedProject.Add(new MulObject(filename,ofd.SafeFileName, 1));

                string jsonString = JsonSerializer.Serialize(_loadedProject);
                File.WriteAllText(_loadedProjectPath + _loadedProjectName+ ".mulstu", jsonString);
                mulListView.SetObjects(_loadedProject);
            }
        }
        private void deleteMulBtn_Click(object sender, EventArgs e)
        {
            deleteMulBtn.Enabled = false;
            File.Delete(@$"{_loadedProjectPath}Resources\{_loadedProject[mulListView.SelectedIndex].FileName}");
            _loadedProject.RemoveAt(mulListView.SelectedIndex);
            mulListView.SetObjects(_loadedProject);
            string jsonString = JsonSerializer.Serialize(_loadedProject);
            File.WriteAllText(_loadedProjectPath + _loadedProjectName + ".mulstu", jsonString);
            
        }
        private void buildBtn_Click(object sender, EventArgs e)
        {
            if (_loadedProject?.Count == 0)
            {
                MessageBox.Show(this,"You need atleast one mul file in your project to build", "Attention",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            List<KeyStamp> keyStamps = new List<KeyStamp>();
            long totalTime = 0;
            bool firstLoop = true;
            long time = 0;
            foreach (var mul in _loadedProject)
            {
                string[] file = File.ReadAllLines(@$"{_loadedProjectPath}Resources\{mul.FileName}");
                long fileTime = long.Parse(file[0].Split('/')[2]);

                for (int i = 0; i < mul.Repeat; i++)
                {
                    foreach (var line in file.Skip(1))
                    {
                        string[] data = line.Split(':');
                        time = long.Parse(data[2]);

                        if (!firstLoop)
                            time += totalTime;
                        
                        if (data.Length == 3)
                            keyStamps.Add(new KeyStamp(int.Parse(data[0]),
                                    data[1] == "T", time));
                        else
                            keyStamps.Add(new KeyStamp(int.Parse(data[0]),
                                   data[1] == "T", time,
                                   int.Parse(data[3]), int.Parse(data[4])));
                    }
                    totalTime += fileTime;
                    firstLoop = false;
                }
            }

            List<string> output = new List<string>();
            output.Add($"</TotalDuration/{time}/>");
            output.AddRange(keyStamps.Select(k => $"{k.Char}:{k.Hold}:{k.Time}{(k.X == 0 && k.Y == 0 ? string.Empty : $":{k.X}:{k.Y}")}"));
            File.WriteAllLines(OutputFolder + _loadedProjectName + ".mul", output);
            MessageBox.Show("Build succeded. Check output folder");
        }

        #region projectlist Controls
        private void createProjectBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ProjectFolder + projectNameTextBox.Text))
            {
                MessageBox.Show("A Project with that name already exist");
            }
            else
            {
                Directory.CreateDirectory(ProjectFolder + projectNameTextBox.Text);
                Directory.CreateDirectory(ProjectFolder + projectNameTextBox.Text + @"\Resources");
                File.Create(ProjectFolder + projectNameTextBox.Text + @"\" + projectNameTextBox.Text + ".mulstu").Close();
                LoadProjects();
                LoadProject(projectNameTextBox.Text);
                projectListbox.SelectedIndex = projectListbox.FindStringExact(_loadedProjectName);
            }
        }

        private void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (projectNameTextBox.Text == string.Empty)
                createProjectBtn.Enabled = false;
            else
                createProjectBtn.Enabled = true;
        }

        private void loadProjectBtn_Click(object sender, EventArgs e)
        {
            LoadProject((string)projectListbox.SelectedItem);
        }

        private void deleteProjectBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(ProjectFolder + projectListbox.SelectedItem))
            {
                Directory.Delete(ProjectFolder + projectListbox.SelectedItem, true);
                if (_loadedProjectName == (string)projectListbox.SelectedItem)
                {
                    _loadedProjectName = "";
                    _loadedProject = null;
                    Text = "Müller Studio";
                    buildBtn.Enabled = false;
                    addMulBtn.Enabled = false;
                    mulListView.SetObjects(null);
                }
                loadProjectBtn.Enabled = false;
                deleteProjectBtn.Enabled = false;
                LoadProjects();
            }
        }

        private void projectListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectListbox.SelectedIndex == -1)
            {
                loadProjectBtn.Enabled = false;
                deleteProjectBtn.Enabled = false;
            }
            else
            {
                loadProjectBtn.Enabled = true;
                deleteProjectBtn.Enabled = true;
            }
        }

        #endregion

        private void mulListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mulListView.SelectedIndex == -1)
            {
                deleteMulBtn.Enabled = false;
            }
            else
            {
                deleteMulBtn.Enabled = true;
            }
        }

        private void outputFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", OutputFolder);
        }
    }
}