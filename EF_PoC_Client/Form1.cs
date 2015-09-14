using System;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using EF_PoC_Customer;

namespace EF_PoC_Client
{
    /// <summary>
    /// Interaction logic for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Fields

        // netTcpBinding.
        static NetTcpBinding netTcpBinding = new NetTcpBinding();

        // endpointAddress.
        static EndpointAddress endpointAddress = new EndpointAddress(new Uri("net.tcp://localhost/EFPoCAppService"));

        // channelFactory.
        ChannelFactory<IServerM> channelFactory = new ChannelFactory<IServerM>(netTcpBinding, endpointAddress);

        // hostServer.
        IServerM hostServer;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Preset values.
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;

            CheckConnectionStatus();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // List
            RefreshGuiTable();
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Delete
            Guid cId;
            string cName;
            Guid aId;
            string aCountry;
            int aZip;
            string aCity;
            string aDistrict;
            string aStreet;
            string aHouse;

            // An item must be selected.
            if (dataGridView1.CurrentCellAddress.X >= 0)
            {
                try
                {
                    // Create a chennel.
                    hostServer = channelFactory.CreateChannel();

                    // Get the values of the selected item.
                    int kijeloltsorindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow kijeloltsor = dataGridView1.Rows[kijeloltsorindex];
                    cId = (Guid)kijeloltsor.Cells["Column1"].Value;
                    cName = kijeloltsor.Cells["Column2"].Value.ToString();
                    aId = (Guid)kijeloltsor.Cells["Column3"].Value;
                    aCountry = kijeloltsor.Cells["Column4"].Value.ToString();
                    aZip = int.Parse(kijeloltsor.Cells["Column5"].Value.ToString());
                    aCity = kijeloltsor.Cells["Column6"].Value.ToString();
                    aDistrict = kijeloltsor.Cells["Column7"].Value.ToString();
                    aStreet = kijeloltsor.Cells["Column8"].Value.ToString();
                    aHouse = kijeloltsor.Cells["Column9"].Value.ToString();

                    // Make delete.
                    if (hostServer.DeleteBoth(aId))
                    {
                        // Refresh
                        RefreshGuiTable();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Delete was unsuccessful."));
                    }

                    // Close channel.
                    ((IClientChannel)hostServer).Close();
                }
                catch
                {
                    MessageBox.Show(string.Format("Delete was unsuccessful."));

                    // Abort channel.
                    if (hostServer != null)
                    {
                        ((ICommunicationObject)hostServer).Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Modify
            Guid cId;
            string cName;
            Guid aId;
            string aCountry;
            int aZip;
            string aCity;
            string aDistrict;
            string aStreet;
            string aHouse;

            // An item must be selected.
            if (dataGridView1.CurrentCellAddress.X >= 0)
            {
                try
                {
                    // Create a chennel.
                    hostServer = channelFactory.CreateChannel();

                    // Get the values of the selected item.
                    int kijeloltsorindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow kijeloltsor = dataGridView1.Rows[kijeloltsorindex];
                    cId = (Guid)kijeloltsor.Cells["Column1"].Value;
                    cName = kijeloltsor.Cells["Column2"].Value.ToString();
                    aId = (Guid)kijeloltsor.Cells["Column3"].Value;
                    aCountry = kijeloltsor.Cells["Column4"].Value.ToString();
                    aZip = int.Parse(kijeloltsor.Cells["Column5"].Value.ToString());
                    aCity = kijeloltsor.Cells["Column6"].Value.ToString();
                    aDistrict = kijeloltsor.Cells["Column7"].Value.ToString();
                    aStreet = kijeloltsor.Cells["Column8"].Value.ToString();
                    aHouse = kijeloltsor.Cells["Column9"].Value.ToString();

                    // Make edit.
                    if (hostServer.ModifyBoth(aId, cId,
                                          new Address(textBox4.Text, int.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, false, new Customer(textBox2.Text, false))))
                    {
                        // Refresh
                        RefreshGuiTable();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Modification was unsuccessful."));
                    }

                    // Close channel.
                    ((IClientChannel)hostServer).Close();
                }
                catch
                {
                    MessageBox.Show(string.Format("Modification was unsuccessful."));

                    // Abort channel.
                    if (hostServer != null)
                    {
                        ((ICommunicationObject)hostServer).Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the button4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            // Add
            // The fields must not be empty.
            if (!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text) &&
                !String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                int.Parse(textBox5.Text) >= 0 &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text)) // Address and customer data is given
            {
                try
                {
                    // Create a chennel.
                    hostServer = channelFactory.CreateChannel();

                    // Make Add.
                    if (hostServer.AddBoth(new Address(textBox4.Text, int.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, false, new Customer(textBox2.Text, false))))
                    {
                        // Refresh
                        RefreshGuiTable();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Adding customer with address was unsuccessful."));
                    }

                    // Close channel.
                    ((IClientChannel)hostServer).Close();
                }
                catch
                {
                    MessageBox.Show(string.Format("Adding customer with address was unsuccessful."));

                    // Abort channel.
                    if (hostServer != null)
                    {
                        ((ICommunicationObject)hostServer).Abort();
                    }
                }
            }
            // The fields must not be empty.
            else if ((!String.IsNullOrEmpty(textBox3.Text) &&
                    !String.IsNullOrEmpty(textBox4.Text) &&
                    int.Parse(textBox5.Text) >= 0 &&
                    !String.IsNullOrEmpty(textBox6.Text) &&
                    !String.IsNullOrEmpty(textBox7.Text) &&
                    !String.IsNullOrEmpty(textBox8.Text) &&
                    !String.IsNullOrEmpty(textBox9.Text))) // Only address data is given
            {
                try
                {
                    // Create a chennel.
                    hostServer = channelFactory.CreateChannel();

                    // Make Add.
                    if (hostServer.AddAddress(new Address(textBox4.Text, int.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, false, null)))
                    {
                        // Refresh
                        RefreshGuiTable();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Adding address was unsuccessful."));
                    }

                    // Close channel.
                    ((IClientChannel)hostServer).Close();
                }
                catch
                {
                    MessageBox.Show(string.Format("Adding address was unsuccessful."));

                    // Abort channel.
                    if (hostServer != null)
                    {
                        ((ICommunicationObject)hostServer).Abort();
                    }
                }
            }
            // The fields must not be empty.
            else if ((!String.IsNullOrEmpty(textBox1.Text) &&
                    !String.IsNullOrEmpty(textBox2.Text))) // Only customer data is given
            {
                try
                {
                    // Create a chennel.
                    hostServer = channelFactory.CreateChannel();

                    // Make Add.
                    if (hostServer.AddCustomer(new Customer(textBox2.Text, false)))
                    {
                        // Refresh
                        RefreshGuiTable();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Adding customer was unsuccessful."));
                    }

                    // Close channel.
                    ((IClientChannel)hostServer).Close();
                }
                catch
                {
                    MessageBox.Show(string.Format("Adding customer was unsuccessful."));

                    // Abort channel.
                    if (hostServer != null)
                    {
                        ((ICommunicationObject)hostServer).Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the button5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            // Refresh status
            CheckConnectionStatus();
        }

        /// <summary>
        /// Handles the CellClick event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Select record
            // An items must be selected.
            if (dataGridView1.CurrentCellAddress.X >= 0)
            {
                try
                {
                    // Get the values of the selected item.
                    int kijeloltsorindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow kijeloltsor = dataGridView1.Rows[kijeloltsorindex];
                    textBox1.Text = kijeloltsor.Cells["Column1"].Value.ToString();
                    textBox2.Text = kijeloltsor.Cells["Column2"].Value.ToString();
                    textBox3.Text = kijeloltsor.Cells["Column3"].Value.ToString();
                    textBox4.Text = kijeloltsor.Cells["Column4"].Value.ToString();
                    textBox5.Text = kijeloltsor.Cells["Column5"].Value.ToString();
                    textBox6.Text = kijeloltsor.Cells["Column6"].Value.ToString();
                    textBox7.Text = kijeloltsor.Cells["Column7"].Value.ToString();
                    textBox8.Text = kijeloltsor.Cells["Column8"].Value.ToString();
                    textBox9.Text = kijeloltsor.Cells["Column9"].Value.ToString();

                    // Enable button.
                    if (label2.Text.ToUpper() != "OFFLINE" && !button2.Enabled)
                    {
                        button2.Enabled = true;
                    }
                }
                catch
                {
                    // Empty values.
                    button2.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                }
            }
            else
            {
                // Empty values.
                button2.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
            }
        }

        /// <summary>
        /// Refreshes the gui table.
        /// </summary>
        private void RefreshGuiTable()
        {
            // Refresh table
            try
            {
                hostServer = channelFactory.CreateChannel();
                Addresses input = hostServer.ListBoth();
                dataGridView1.Rows.Clear();

                if (input != null)
                {
                    if (input.Count > 0)
                    {
                        foreach (Address oneAddress in input)
                        {
                            // Fill the dataGridView1 with the Address and Customer table values.
                            if (!oneAddress.IsDeleted && (oneAddress.Customer != null ? !oneAddress.Customer.IsDeleted : true)) // Logical deleting
                            {
                                DataGridViewRow row = new DataGridViewRow();

                                DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell5 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell6 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell7 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell8 = new DataGridViewTextBoxCell();
                                DataGridViewCell cell9 = new DataGridViewTextBoxCell();

                                cell1.Value = oneAddress.CustomerId;
                                row.Cells.Add(cell1);
                                if (oneAddress.Customer != null)
                                {
                                    cell2.Value = oneAddress.Customer.CustomerName;
                                    row.Cells.Add(cell2);
                                }
                                else
                                {
                                    cell2.Value = "";
                                    row.Cells.Add(cell2);
                                }
                                cell3.Value = oneAddress.Id;
                                row.Cells.Add(cell3);
                                cell4.Value = oneAddress.CountryName;
                                row.Cells.Add(cell4);
                                cell5.Value = oneAddress.ZipCode;
                                row.Cells.Add(cell5);
                                cell6.Value = oneAddress.CityName;
                                row.Cells.Add(cell6);
                                cell7.Value = oneAddress.DistrictNumber;
                                row.Cells.Add(cell7);
                                cell8.Value = oneAddress.StreetName;
                                row.Cells.Add(cell8);
                                cell9.Value = oneAddress.HouseNumber;
                                row.Cells.Add(cell9);

                                #region Comment

                                //if (oneCustomer.Customer != null)
                                //{
                                //    foreach (var oneCell in oneCustomer.Customer.CustomerAddresses)
                                //    {
                                //        DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell3 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell5 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell6 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell7 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell8 = new DataGridViewTextBoxCell();
                                //        DataGridViewCell cell9 = new DataGridViewTextBoxCell();

                                //        cell1.Value = oneCustomer.CustomerId;
                                //        row.Cells.Add(cell1);
                                //        cell2.Value = oneCustomer.Customer.CustomerName;
                                //        row.Cells.Add(cell2);
                                //        cell3.Value = oneCell.AddressId;
                                //        row.Cells.Add(cell3);
                                //        cell4.Value = oneCell.CountryName;
                                //        row.Cells.Add(cell4);
                                //        cell5.Value = oneCell.ZipCode;
                                //        row.Cells.Add(cell5);
                                //        cell6.Value = oneCell.CityName;
                                //        row.Cells.Add(cell6);
                                //        cell7.Value = oneCell.DistrictNumber;
                                //        row.Cells.Add(cell7);
                                //        cell8.Value = oneCell.StreetName;
                                //        row.Cells.Add(cell8);
                                //        cell9.Value = oneCell.HouseNumber;
                                //        row.Cells.Add(cell9);

                                //        dataGridView1.Rows.Add(row);
                                //    }
                                //}
                                //else
                                //{
                                //    DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                                //    DataGridViewCell cell2 = new DataGridViewTextBoxCell();

                                //    cell1.Value = oneCustomer.CustomerId;
                                //    row.Cells.Add(cell1);
                                //    cell2.Value = oneCustomer.Customer.CustomerName;
                                //    row.Cells.Add(cell2);
                                //}

                                #endregion Comment

                                dataGridView1.Rows.Add(row);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Zero records found."));
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("No records found."));
                }

                // Close channel.
                ((IClientChannel)hostServer).Close();
            }
            catch
            {
                // Abort channel.
                if (hostServer != null)
                {
                    ((ICommunicationObject)hostServer).Abort();
                    MessageBox.Show(string.Format("List failed."));
                }
            }
        }

        /// <summary>
        /// Checls the connection status.
        /// </summary>
        private void CheckConnectionStatus()
        {
            // Checks for the server
            try
            {
                // Create a channel.
                hostServer = channelFactory.CreateChannel();

                // Make Login.
                if (hostServer.Login("test") != null)
                {
                    // Set values for online server.
                    label2.Text = string.Format("ONLINE");
                    label2.ForeColor = Color.Green;

                    button1.Enabled = true;
                }

                // Close the channel.
                ((IClientChannel)hostServer).Close();
            }
            catch
            {
                // Abort the channel.
                if (hostServer != null)
                {
                    ((ICommunicationObject)hostServer).Abort();
                }

                // Set values for offline server.
                label2.Text = string.Format("OFFLINE");
                label2.ForeColor = Color.Red;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        #region TextChanged

        /// <summary>
        /// Handles the TextChanged event of the textBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Customer id is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Customer name is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Address id is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Address country is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Address zipcode is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Address city is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            // Address district number is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            // Address street is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox9 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            // Address house number is changed
            // The fields must not be empty.
            if (label2.Text.ToUpper() != "OFFLINE" &&
                ((!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text)) ||
                (!String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox5.Text) &&
                !String.IsNullOrEmpty(textBox6.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&
                !String.IsNullOrEmpty(textBox8.Text) &&
                !String.IsNullOrEmpty(textBox9.Text))))
            {
                // Enable the buttons.
                if (!button3.Enabled)
                {
                    button3.Enabled = true;
                }
                if (!button4.Enabled)
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                // Disable the buttons.
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        #endregion TextChanged

        #endregion Methods
    }
}
