using System.Linq.Expressions;

namespace File_Manager;


partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    //Clean any resources
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    //Initialises application window
    private void initialise_component()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "File Manager";
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
    }
    
    //Page 1 information
    private void page_1()
    {
        initialise_component();
        page_1_text();
        start_button();
    }

    private void page_1_text()
    {
        Label text = new Label();
        text.Location = new Point(270, 100);
        text.Text = "Hello, I am File Manager.\n     Click start to begin.";
        text.Font = new Font("Open Sans", 18);
        text.AutoSize = true;
        Controls.Add(text);
    }

    private void start_button()
    {
        Button button = new Button();
        button.Text = "Start";
        button.Location = new Point(380, 350);
        button.AutoSize = true;
        button.Click += new EventHandler(start_button_click);
        Controls.Add(button);
    }

    private void start_button_click(object sender, EventArgs e)
    {
        Controls.Clear();
        page_2();
    }

    //Page 2 information
    private void page_2()
    {
        initialise_component();
        page_2_text();
    }

    private void page_2_text()
    {
        //Page GUI components
        Label check_folder = new Label();
        Label destination_folder = new Label();
        Label file_type_label = new Label();
        Label file_name = new Label();

        Button select_check_folder = new Button();
        Button select_destination_folder = new Button();
        Button run = new Button();

        TextBox file_type = new TextBox();
        TextBox file_name_text = new TextBox();
        
        //Organising and displaying GUI components
        check_folder.Location = new Point(80, 50);
        check_folder.Text = "Select folder to organise";
        check_folder.Size = new Size(200, 30);
        check_folder.Font = new Font("Open Sans", 12);

        destination_folder.Location = new Point(300, 50);
        destination_folder.Text = "Select destination folder";
        destination_folder.Size = new Size(200, 30);
        destination_folder.Font = new Font("Open Sans", 12);

        file_type_label.Location = new Point(520, 50);
        file_type_label.Text = "File type (png, jpeg, pdf, etc)";
        file_type_label.AutoSize = true;
        file_type_label.Font = new Font("Open Sans", 12);

        select_check_folder.Location = new Point(120, 80);
        select_check_folder.Text = "Select folder";
        select_check_folder.AutoSize = true;
        select_check_folder.Font = new Font("Open Sans", 12);

        select_destination_folder.Location = new Point(340, 80);
        select_destination_folder.Text = "Select Folder";
        select_destination_folder.AutoSize = true;
        select_destination_folder.Font = new Font("Open Sans", 12);

        file_type.Location = new Point(570, 80);
        file_type.AutoSize = true;
        file_type.Font = new Font("Open Sans", 12);

        file_name.Location = new Point(260, 130);
        file_name.Text = "Optional: What does the file begin with";
        file_name.AutoSize = true;
        file_name.Font = new Font("Open Sans", 12);

        file_name_text.Location = new Point(350, 170);
        file_name_text.AutoSize = true;
        file_name_text.Font = new Font("Open Sans", 12);

        run.Location = new Point(370, 300);
        run.Text = "Run";


        select_destination_folder.Click += (sender, EventArgs)=>{select_folder(sender, EventArgs, destination_folder);};
        select_check_folder.Click += (sender, EventArgs)=>{select_folder(sender, EventArgs, check_folder);};

        //Run button click event
        run.Click += (sender, EventArgs) => 
        {
            //Stored variables
            string check = check_folder.Text;
            string destination = destination_folder.Text;
            string file = file_name_text.Text;
            string type = file_type.Text;

            running(sender, EventArgs, check, destination, file, type); 
        };

        //Adds all GUI components
        Controls.Add(check_folder);
        Controls.Add(destination_folder);
        Controls.Add(file_type_label);
        Controls.Add(file_name);
        Controls.Add(file_name_text);
        Controls.Add(select_check_folder);
        Controls.Add(select_destination_folder);
        Controls.Add(run);
        Controls.Add(file_type);  
    }

    //Folder selector
    private void select_folder(object sender, EventArgs e, Label label)
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        DialogResult result = folderBrowserDialog.ShowDialog();

        if(result == DialogResult.OK)
        {
            label.Text = folderBrowserDialog.SelectedPath;
        }
    }
    //Calls manager function to organise files
    private void running(object sender, EventArgs e, string check, string destination, string file, string type)
    {
        Manager manager = new Manager();
        //Error handling
        if(check == "Select folder to organise" || destination == "Select destination folder" || type == "")
        {
            MessageBox.Show("One or more of the required fields have not been filled", "Error", MessageBoxButtons.OK);
        }
        else {manager.manage(check, destination, file, type);}
    }
}

