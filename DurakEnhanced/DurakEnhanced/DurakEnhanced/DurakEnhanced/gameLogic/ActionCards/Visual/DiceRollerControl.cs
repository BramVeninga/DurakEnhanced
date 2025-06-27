using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakEnhanced.gameLogic.ActionCards.Visual
{
    public partial class DiceRollerControl : UserControl
    {
        private List<Image> currentFrames;
        private int currentFrameIndex;
        private Timer animationTimer;
        private PictureBox animationBox;
        private string framesPath = "Resources/DiceRollFrames";
        private Action<int> onAnimationFinished;
        private Timer hideTimer;

        public DiceRollerControl()
        {
            InitializeComponent();
            InitializeAnimationComponents();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void InitializeAnimationComponents()
        {
            animationBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.Controls.Add(animationBox);

            animationTimer = new Timer
            {
                Interval = 90 // Adjust speed
            };

            animationTimer.Tick += AnimationTick;

            hideTimer = new Timer
            {
                Interval = 4000 // 4 seconds after animation ends
            };

            hideTimer.Tick += (s, e) =>
            {
                this.Visible = false;
                hideTimer.Stop();
            };
        }

        public void RollD20(Action<int> onFinished = null)
        {
            animationTimer.Stop(); // Just in case
            animationBox.Image = null; // ✅ Clear the previous frame immediately

            int result = new Random().Next(1, 21);
            Console.WriteLine($"[RollD20] Rolled value: {result}");

            try
            {
                LoadFrames(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RollD20] Failed to load frames: {ex.Message}");
                MessageBox.Show("Error loading dice animation frames.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            onAnimationFinished = onFinished;
            currentFrameIndex = 0;
            animationTimer.Start();
        }

        private void LoadFrames(int result)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, framesPath, result.ToString());

            Console.WriteLine($"[LoadFrames] Looking for images in: {folder}");

            if (!Directory.Exists(folder))
                throw new DirectoryNotFoundException($"Frame directory not found: {folder}");

            string[] files = Directory.GetFiles(folder, "*.png");

            if (files.Length == 0)
                throw new FileNotFoundException("No PNG frames found in: " + folder);

            Array.Sort(files); // Ensure consistent order

            currentFrames = new List<Image>();

            foreach (var file in files)
            {
                Console.WriteLine($"[LoadFrames] Loading: {file}");
                var image = Image.FromFile(file);
                image.Tag = file;
                currentFrames.Add(image);
            }
        }

        private void AnimationTick(object sender, EventArgs e)
        {
            if (currentFrames == null || currentFrames.Count == 0)
            {
                Console.WriteLine("[AnimationTick] No frames loaded.");
                animationTimer.Stop();
                return;
            }

            if (currentFrameIndex >= currentFrames.Count)
            {
                Console.WriteLine("[AnimationTick] Animation finished.");
                animationTimer.Stop();
                int result = GetResultFromFrames();
                Console.WriteLine($"[AnimationTick] Result from animation: {result}");
                onAnimationFinished?.Invoke(result);
                hideTimer.Start();
                return;
            }

            Console.WriteLine($"[AnimationTick] Displaying frame {currentFrameIndex + 1}/{currentFrames.Count}");
            animationBox.Image = currentFrames[currentFrameIndex];
            currentFrameIndex++;
        }

        private int GetResultFromFrames()
        {
            try
            {
                string tagPath = currentFrames[0]?.Tag?.ToString();
                if (string.IsNullOrEmpty(tagPath))
                {
                    Console.WriteLine("[GetResultFromFrames] Invalid tag.");
                    return -1;
                }

                string folder = Path.GetFileName(Path.GetDirectoryName(tagPath));
                Console.WriteLine($"[GetResultFromFrames] Folder: {folder}");

                return int.TryParse(folder.Replace("r", ""), out int value) ? value : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetResultFromFrames] Exception: {ex.Message}");
                return -1;
            }
        }

        private void dicePictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
