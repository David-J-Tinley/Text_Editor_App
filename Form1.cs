//
// Text Editor Application
// 06/12/2023
// David J Tinley
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Text_Editor_App
{
    public partial class form_Main : Form
    {
        // Get the default font
        Font default_font;

        // Set the split character for the word count total
        private char[] split_characters = "\n,.:;\"'?!".ToArray();

        // Flag if editing is in progress
        bool editing_in_progress = false;

        // Variables
        string file_to_open;
        string file_to_save;
        string retrieved_text = "";

        public form_Main()
        {
            InitializeComponent();
        }

        // Adds Exit functionality to "File -> Exit"
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Centers the Application on the screen upon opening
        private void form_Main_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            // Handle initial word wrap option
            if (text_content.WordWrap)
            {
                wordWrapOffToolStripMenuItem.Text = "Word Wrap is On";
            }
            else
            {
                wordWrapOffToolStripMenuItem.Text = "Word Wrap is Off";
            }
        }

        // Function that handles Opening of Files from the menu
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if editing is in progress and handle accordingly
            if (editing_in_progress)
            {
                DialogResult dr_discard = MessageBox.Show(this, "You are currently editing this file." + Environment.NewLine + "Discard changes?", "Open text document", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr_discard != DialogResult.Yes)
                {
                    return;
                }
            }

            // Displays the open file dialog from "File -> Open"
            DialogResult dr = dialog_open_file.ShowDialog();

            //
            if (dr == DialogResult.OK)
            {
                // Get the path of the file to be opened
                string file_to_open = @dialog_open_file.FileName;

                // Read file and display in rich text box
                try
                {
                    // Read all the text from the file to be opened
                    text_content.Text = File.ReadAllText(@file_to_open);

                    // Set status label to show file that was opened
                    status_label.Text = "Opened File: " + @file_to_open;

                    // Editing in progress is now true
                    editing_in_progress = true;
                    this.Text = "Text Editor: " + @file_to_open;
                }
                catch (Exception ex)
                {
                    // If issue, display error message
                    MessageBox.Show(this, "Error Message ", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        // Function that handles Saving of Files from the menu
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = dialog_save_file.ShowDialog();

            // If user clicks selects a path to save the file
            if (dr == DialogResult.OK)
            {
                string file_to_save = @dialog_save_file.FileName;

                try
                {
                    // Write all of the text from the current file
                    File.WriteAllText(@file_to_save, @text_content.Text);

                    // Display Saved File path
                    status_label.Text = "File Saved As: " + @file_to_save;

                    // No longer editing
                    editing_in_progress = false;

                    this.Text = "Text Editor: " + @file_to_save;
                }
                catch (Exception ex)
                {
                    // Display message if there's an error
                    MessageBox.Show(this, "Error Message", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        // Function that handles making a New File from the menu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if currently editing a file
            if (editing_in_progress)
            {
                DialogResult dr = MessageBox.Show(this, "You are currently editing this file." + Environment.NewLine + "Discard Changes?", "New Text File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                // If user selected "Yes"
                if (dr == DialogResult.Yes)
                {
                    // Clear the content in the text box
                    text_content.Clear();

                    // Set status label to show new text file
                    status_label.Text = "New Text File";

                    this.Text = "Text Editor: New Text File";
                }
                else
                {
                    return;
                }
            }
            else
            {
                text_content.Clear();
                status_label.Text = "New Text File";
                this.Text = "Text Editor: New Text File";
            }

            // Editing is now true for new file
            editing_in_progress = true;
        }

        // Function that handles word wrapping option in format menu
        private void wordWrapOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If word wrap is already on
            if (text_content.WordWrap)
            {
                text_content.WordWrap = false;
                wordWrapOffToolStripMenuItem.Text = "Word Wrap is Off";
            }
            // If word wrap is already off
            else
            {
                text_content.WordWrap = true;
                wordWrapOffToolStripMenuItem.Text = "Word Wrap is On";
            }
        }

        // Function that handles increase font size option in format menu
        private void increaseFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set 20 as maximum font size
            if (text_content.Font.Size < 20)
            {
                // Increase font size by 2
                text_content.Font = new Font("Microsoft Sans Serif", text_content.Font.Size + 2);
            }
            // Else display message box with warning
            else
            {
                MessageBox.Show(this, "Max Font Size Reached: (" + Convert.ToInt32(text_content.Font.Size).ToString() + ")", "Increase Font Size", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void decreaseFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set 8 as minimum font size
            if (text_content.Font.Size > 10)
            {
                // Decrease font size by 2
                text_content.Font = new Font("Microsoft Sans Serif", text_content.Font.Size - 2);
            }
            else
            {
                MessageBox.Show(this, "Minimum Font Size Reached: (" + Convert.ToInt32(text_content.Font.Size).ToString() + ")", "Decrease Font Size", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Function that handles reset to default font size option in format menu
        private void resetFontSizeToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text_content.Font = default_font;
        }
    }
}
