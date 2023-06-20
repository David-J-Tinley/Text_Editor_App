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
using System.Text.RegularExpressions;

namespace Text_Editor_App
{
    public partial class form_Main : Form
    {
        // Get the default font
        Font default_font;

        // Set the split character for the word count total
        private char[] split_characters = "\n,' '.:;\"'?!".ToArray();

        // Flag if editing is in progress
        bool editing_in_progress = false;

        // Variables
        string file_to_open;
        string file_to_save;
        string retrieved_text = "";

        // Main form initializing function
        public form_Main()
        {
            InitializeComponent();
        }

        // Adds Exit functionality to "File -> Exit"
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Main form loading function
        private void form_Main_Load(object sender, EventArgs e)
        {
            // Centers the Application on the screen upon opening
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

            // Defining default font at load time
            default_font = text_content.Font;
        }

        // Handles Opening of Files from the menu
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if editing is in progress and handle accordingly
            if (editing_in_progress)
            {
                DialogResult dr_discard = MessageBox.Show(this, "You are currently editing this file." + Environment.NewLine + "Save changes to current file?", "Open text document", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                // Save before opening new file if user selects 'yes'
                if (dr_discard == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }

                // Return if user cancels opening
                if (dr_discard == DialogResult.Cancel)
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
                file_to_open = @dialog_open_file.FileName;

                // Read file and display in rich text box
                try
                {
                    // Read all the text from the file to be opened
                    // text_content.Text = File.ReadAllText(@file_to_open);

                    // Set status label to show file that was opened
                    // status_label.Text = "Opened File: " + @file_to_open;

                    // Editing in progress is now true
                    // editing_in_progress = true;
                    // this.Text = "Text Editor: " + @file_to_open;

                    // Open the file by calling a separate thread via the bgWorker object
                    if (!open_file_bgWorker.IsBusy)
                    {
                        open_file_bgWorker.RunWorkerAsync();
                    }

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

        // Handles Saving of Files from the menu
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = dialog_save_file.ShowDialog();

            // If user clicks selects a path to save the file
            if (dr == DialogResult.OK)
            {
                file_to_save = @dialog_save_file.FileName;

                try
                {
                    // Write all of the text from the current file
                    // File.WriteAllText(@file_to_save, @text_content.Text);

                    // Display Saved File path
                    // status_label.Text = "File Saved As: " + @file_to_save;

                    // No longer editing
                    // editing_in_progress = false;

                    // this.Text = "Text Editor: " + @file_to_save;

                    if (!save_file_bgWorker.IsBusy)
                    {
                        save_file_bgWorker.RunWorkerAsync();
                    }
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

        // Handles making a New File from the menu
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

        // Handles word wrapping option in format menu
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

        // Handles increase font size option in format menu
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

        // Handles decrease font size option in format menu
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

        // Handles reset to default font size option in format menu
        private void resetFontSizeToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text_content.Font = default_font;
        }

        // Handles the "about" option in Help menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Text Editor made with WinForms (C#/.NET Framework)", "About the editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Handles text being changed in the rich text box
        private void text_content_TextChanged(object sender, EventArgs e)
        {
            update_status_line();
            editing_in_progress = true;
        }

        // Updates status line w/ line #, total lines, word count
        private void update_status_line()
        {
            status_label.Text = "Editing Line: " + (text_content.GetLineFromCharIndex(text_content.SelectionStart) + 1).ToString() + " - Total Lines: " + text_content.Lines.Count().ToString() + " - Total Words: " + text_content.Text.Split(split_characters, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
        }

        // Handles key down events in rich text box
        private void key_down(object sender, KeyEventArgs e)
        {
            // Handles the copy-paste event in order to paste as plain text only
            if (e.Control && e.KeyCode == Keys.V)
            {
                text_content.Text += (string)Clipboard.GetData("Text");
                e.Handled = true;
            }
            // Handles the ctrl-s (save) combination
            if (e.Control && e.KeyCode == Keys.S)
            {
                saveAsToolStripMenuItem_Click(sender, e);
                e.Handled = true;
            }
        }

        // Handles closing event
        private void form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if editing is in progress
            if (editing_in_progress)
            {
                DialogResult dr = MessageBox.Show(this, "You are currently editing a file." + Environment.NewLine + "Would you like to save before closing?", "Close the Text Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                // Use save as function if yes is chosen
                if (dr == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
                // If no is chosen, editor closes without saving
                // If Cancel is chosen, editor cancels the closing event
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void open_file_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Retrieve the file contents using a separate thread/process
            try
            {
                retrieved_text = File.ReadAllText(@file_to_open);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void open_file_bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // After file contents are retrieved, perform the rest of the tasks
            text_content.Text = retrieved_text;
            status_label.Text = "Opened File: " + @file_to_open;
            editing_in_progress = true;
            this.Text = "Text Editor: " + @file_to_open;

            // Update status line with opened file info
            update_status_line();
        }

        private void save_file_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Save the file using a separate thread/process
            try
            {
                if (text_content.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        File.WriteAllText(@file_to_save, text_content.Text);
                    });
                }
                else
                {
                    File.WriteAllText(@file_to_save, text_content.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error Message", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save_file_bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // After the file is saved via the separate thread, perform the rest of the tasks
            status_label.Text = "File Saved As: " + @file_to_save;
            editing_in_progress = false;
            this.Text = "Text Editor: " + @file_to_save;

            // Update status line with saved file
            update_status_line();
        }
    }
}
