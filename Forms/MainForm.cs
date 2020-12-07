using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Visualizer.Algorithms;
using Visualizer.Algorithms.Tools;
using Visualizer.Classes;

namespace Visualizer.Forms
{
    public partial class MainForm : Form
    {
        // Dimensions
        private const int GRID_WIDTH = 39;
        private const int GRID_HEIGHT = 24;
        private const int BLOCK_WIDTH = 25;
        private const int BLOCK_HEIGHT = 25;

        private const int DELAY = 10;

        private readonly Color _ButtonSelectedColor = Color.CadetBlue;
        private readonly Grid _grid = new Grid();

        private CreditsForm creditsForm;
        private BlockType _selectedBlockType = BlockType.Empty;
        private bool _haveOrigin = false;
        private bool _haveTarget = false;
        private bool _isRunning = false;

        private Coord aCoord;
        private Coord bCoord;

        public MainForm()
        {
            InitializeComponent();
            InitComboBox();     
            GenerateGrid();
            SetTimer();
        }

        public Algorithms.Algorithms CurrentAlgorithm { get; set; }

        #region Initialization
        private void InitComboBox()
        {
            comboBox.Items.Add("Dijkstra's");
            comboBox.Items.Add("A*");
            comboBox.Items.Add("Breadth-First");
            comboBox.Items.Add("Depth-First");
            comboBox.SelectedItem = comboBox.Items[0];
        }

        private void GenerateGrid()
        {
            for (int x = 0; x < GRID_WIDTH; x++)
            {
                for (int y = 0; y < GRID_HEIGHT; y++)
                {
                    var nBlock = new Block(x, y)
                    {
                        Width = BLOCK_WIDTH,
                        Height = BLOCK_HEIGHT,
                        AutoSize = false,
                        Location = new Point(x * BLOCK_WIDTH, y * BLOCK_HEIGHT),
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand,
                    };

                    var costSpread = new Random().Next(0, 10);

                    if (costSpread > 8)
                        nBlock.Cost = 3;
                    else if (costSpread > 6)
                        nBlock.Cost = 2;
                    else
                        nBlock.Cost = 1;

                    // ActionEvents
                    nBlock.Click += Block_Click;                 
                    _grid.Blocks.Add(nBlock);
                    panelGrid.Controls.Add(nBlock);
                    nBlock.Draw();
                }
            }
        }

        private void SetTimer()
        {
            timer.Interval = DELAY;
            timer.Tick += Tick;
            timer.Stop();
        }
        #endregion

        private void ResetGrid()
        {
            _grid.Reset();
            _haveOrigin = false;
            _haveTarget = false;
        }

        private void ShowPath(DetailsOfSearch details)
        {
            for (var i = 1; i < details.Path.Length - 1; i++)
            {
                var step = details.Path[i];
                _grid.SetBlock(step.X, step.Y, BlockType.Path);
                _grid.GetBlock(step.X, step.Y).Draw();
                Thread.Sleep(25);
                Update();
            }

            Console.WriteLine("Founded with sucess");
            _isRunning = false;
        }

        private void Tick(object sender, EventArgs e)
        {
            timer.Stop();
            var resetTimer = false;
            var searchStatus = CurrentAlgorithm.GetPathTick();

            if (searchStatus.PathFound)
                ShowPath(searchStatus);          
            else
            {
                resetTimer = CheckContinuous();

                foreach (var block in _grid.Blocks)
                {
                    if (block.Coord == aCoord)
                    {
                        block.Type = BlockType.A;
                        block.Draw();
                        Update();
                        break;
                    }
                }
            }               

            if (resetTimer)
                timer.Start();     
        }
    
        private bool CheckContinuous()
        {
            if (!CurrentAlgorithm.GetPathTick().PathPossible)
            {
                _grid.CleanToRun(aCoord, bCoord);
                MessageBox.Show("The path is impossible to finde the target", "Cannot find :(");
                Console.WriteLine("failed");
                return false;
            }

            return true;
        }

        #region Buttons
        private void LabelPutOrigin_Click(object sender, EventArgs e)
        {
            // Set colors
            labelPutWall.BackColor = Color.White;
            labelPutTarget.BackColor = Color.White;
            labelPutFreePath.BackColor = Color.White;
            labelPutOrigin.BackColor = _ButtonSelectedColor;

            _selectedBlockType = BlockType.A;
        }

        private void LabelPutTarget_Click(object sender, EventArgs e)
        {
            // Set colors
            labelPutOrigin.BackColor = Color.White;
            labelPutWall.BackColor = Color.White;
            labelPutFreePath.BackColor = Color.White;
            labelPutTarget.BackColor = _ButtonSelectedColor;

            _selectedBlockType = BlockType.B;
        }

        private void LabelPutWall_Click(object sender, EventArgs e)
        {
            // Set colors
            labelPutOrigin.BackColor = Color.White;
            labelPutTarget.BackColor = Color.White;
            labelPutFreePath.BackColor = Color.White;
            labelPutWall.BackColor = _ButtonSelectedColor;

            _selectedBlockType = BlockType.Solid;
        }

        private void LabelPutFreePath_Click(object sender, EventArgs e)
        {
            // Set colors
            labelPutOrigin.BackColor = Color.White;
            labelPutTarget.BackColor = Color.White;
            labelPutWall.BackColor = Color.White;
            labelPutFreePath.BackColor = _ButtonSelectedColor;

            _selectedBlockType = BlockType.Empty;
        }

        private void LabelReset_Click(object sender, EventArgs e)
        {
            ResetGrid();
        }

        private void LabelRun_Click(object sender, EventArgs e)
        {
            if (_haveOrigin && _haveTarget)
            {
                _grid.CleanToRun(aCoord, bCoord);

                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        CurrentAlgorithm = new Dijkstra(_grid);
                        break;
                    case 1:
                        CurrentAlgorithm = new AStar(_grid);
                        break;
                    case 2:
                        CurrentAlgorithm = new BreadthFirst(_grid);
                        break;
                    case 3:
                        CurrentAlgorithm = new DepthFirst(_grid);
                        break;
                    default:
                        throw new Exception($"Unexpected algorithm index '{comboBox.SelectedIndex}'");
                }

                if (_isRunning)
                    Console.WriteLine("canceled");
                Console.Write($"Running {CurrentAlgorithm._algorithmName} - ");

                timer.Start();
                _isRunning = true;
            }
            else
            {
                MessageBox.Show("Origin and target are needed", "Cannot run");
            }
        }

        private void LabelCredits_Click(object sender, EventArgs e)
        {
            creditsForm = new CreditsForm();
            creditsForm.Show();
        }

        private void LabelSite_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://www.eduardo-ribeiro-leal.com");
            } catch
            {
                MessageBox.Show("Cannot open the link 'https://www.eduardo-ribeiro-leal.com' " +
                    "in your browser", "Error openning link");
            }
        }

        private void Block_Click(object sender, EventArgs e)
        {
            var block = (Block)sender;

            if (block.Type == _selectedBlockType) return;

            if (_selectedBlockType == BlockType.A && _haveOrigin)
            {
                MessageBox.Show("The origin already exists and can have only one",
                    "The origin already exist");
                return;
            }

            if (_selectedBlockType == BlockType.B && _haveTarget)
            {
                MessageBox.Show("The target already exists and can have only one",
                    "The target already exist");
                return;
            }

            if (_selectedBlockType == BlockType.A)
            {
                aCoord = block.Coord;
                _haveOrigin = true;
            }
                
            else if (_selectedBlockType == BlockType.B)
            {
                bCoord = block.Coord;
                _haveTarget = true;
            }   

            if (block.Type == BlockType.A)
                _haveOrigin = false;
            else if (block.Type == BlockType.B)
                _haveTarget = false;

            block.Type = _selectedBlockType;
            block.Draw();
        }
        #endregion      
    }
}
