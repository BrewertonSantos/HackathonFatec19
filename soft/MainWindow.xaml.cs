using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace soft
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Barreira
        private void BarreiraBtn_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Container.Children.Add(new _sources.Barreira());
        }
        #endregion

        #region Dispositivos
        private void DispositivosBtn_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Container.Children.Add(new _sources.Dispositivo());
        }
        #endregion

        #region Exibicao
        private void ExibicaoBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ExibicaoBtn.Foreground = Brushes.Black;
        }

        private void ExibicaoBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ExibicaoBtn.Foreground = Brushes.White;
        }

        private void ExibicaoBtn_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Container.Children.Add(new _sources.ListView());
        }
        #endregion

        #region Fabricante
        private void FabricanteBtn_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            Container.Children.Add(new _sources.Fabricante());
        }

        private void CadastroBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            CadastroBtn.Foreground = Brushes.Black;
        }

        private void CadastroBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            CadastroBtn.Foreground = Brushes.White;
        }
        #endregion
    }
}
