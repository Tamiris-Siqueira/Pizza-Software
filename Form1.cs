using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Pizzaria
{
    public partial class Form1 : Form
    {
        string pedido, dados;
        double total, troco, pago, pizza, refri, extras;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair da página?", "Atenção!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar?", "Atenção!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Control limpar in this.Controls)
                {
                    if (limpar is RadioButton)
                        if (((RadioButton)limpar).Checked)
                            ((RadioButton)limpar).Checked = false;
                    if (limpar is CheckBox)
                        if (((CheckBox)limpar).Checked)
                            ((CheckBox)limpar).Checked = false;
                    if (limpar is ComboBox)
                        if (((ComboBox)limpar).SelectedIndex > -1)
                            ((ComboBox)limpar).SelectedIndex = -1;
                    if (limpar is TextBox)
                    {
                        if (((TextBox)limpar).Text != txtSalvos.Text)
                            ((TextBox)limpar).Text = "";
                    }

                    total = 0;
                    pizza = 0;
                    refri = 0;
                    extras = 0;
                }
            }

        }

        private void chkBorda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBorda.Checked)
            {
                pedido += "Borda recheada: " + cmbBorda.SelectedItem + "\n";
                extras += 3.00;
            }
        }

        private void chkMassa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMassa.Checked)
            {
                pedido += "Massa Integral" + "\n";
                extras += 3.00;
            }
        }

        private void chkExpresso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpresso.Checked)
            {
                pedido += "Pedido Expresso" + "\n";
                extras += 3.00;
            }
        }

        private void chkOutros_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOutros.Checked)
            {
                pedido += "Observação: " + txtOutros.Text + "\n";
            }
        }

        private void radEntregar_CheckedChanged(object sender, EventArgs e)
        {
            if (radEntregar.Checked)
            {
                pedido += "Pedido Delivery" + "\n";
                total += extras + refri + pizza + 3.00;
            }

            txtTotal.Text = "" + total.ToString("0.00");
        }

        private void radRetirar_CheckedChanged(object sender, EventArgs e)
        {
            if (radRetirar.Checked)
            {
                pedido += "Retirada no local" + "\n";
            }

            total += extras + refri + pizza;
            txtTotal.Text = "" + total.ToString("0.00");
        }

        private void cmbPizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPizza.Text == "Alho")
            {
                pedido += "Pizza: Alho" + "\n";
                pizza += 14.00;
            }
            else if (cmbPizza.Text == "Atum")
            {
                pedido += "Pizza: Atum" + "\n";
                pizza += 15.00;
            }
            else if (cmbPizza.Text == "Brócolis")
            {
                pedido += "Pizza: Brócolis" + "\n";
                pizza += 16.00;
            }
            else if (cmbPizza.Text == "Calabresa")
            {
                pedido += "Pizza: Calabresa" + "\n";
                total += 17.00;
            }
            else if (cmbPizza.Text == "Camarão")
            {
                pedido += "Pizza: Camarão" + "\n";
                pizza += 22.00;
            }
            else if (cmbPizza.Text == "Marguerita")
            {
                pedido += "Pizza: Marguerita" + "\n";
                pizza += 19.00;
            }
            else if (cmbPizza.Text == "Mussarela")
            {
                pedido += "Pizza: Mussarela" + "\n";
                pizza += 15.00;
            }
            else if (cmbPizza.Text == "Pepperoni")
            {
                pedido += "Pizza: Pepperoni" + "\n";
                pizza += 22.00;
            }
            else if (cmbPizza.Text == "Portuguesa")
            {
                pedido += "Pizza: Portuguesa" + "\n";
                pizza += 22.00;
            }
            if(chkMeio.Checked)
            {
                cmbPizza.Text = "";
                pizza = pizza / 2;
            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbPizza_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbBorda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void chkMeio_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMeio.Checked)
            {
                cmbPizza.Text = "";
                pizza = pizza / 2;
                pedido += "Meio a Meio \n";
            }
        }

        private void cmbRefrigerante_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbRefrigerante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRefrigerante.Text == "Cola-Cola")
            {
                pedido += "Refrigerante: Cola-Cola" + "\n";
                refri += 12.00;
            }
            else if (cmbRefrigerante.Text == "Fanta Uva")
            {
                pedido += "Refrigerante: Fanta Uva" + "\n";
                refri += 10.00;
            }
            else if (cmbRefrigerante.Text == "Fanta Laranja")
            {
                pedido += "Refrigerante: Fanta Laranja" + "\n";
                refri += 10.00;
            }
            else if (cmbRefrigerante.Text == "Guaraná")
            {
                pedido += "Refrigerante: Guaraná" + "\n";
                refri += 8.00;
            }
            else if (cmbRefrigerante.Text == "Sprite")
            {
                pedido += "Refrigerante: Sprite" + "\n";
                refri += 8.00;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text.Trim().Length > 0) && (txtEndereco.Text.Trim().Length > 0) && (txtTelefone.Text.Trim().Length >= 8) && (cmbCidade.Text.Trim().Length > 0) && (Double.Parse(txtPago.Text) >= Double.Parse(txtTotal.Text)) && (Double.Parse(txtTotal.Text) > 8))
            {
                dados = "Nome: " + txtNome.Text + "\n" + "Telefone: " + txtTelefone.Text + "\n" + "Endereço: " + txtEndereco.Text + "\n" + "Cidade: " + cmbCidade.SelectedItem + "\n";

                dados += "Total: " + txtTotal.Text + "\n" + "Modo de pagamento: " + cmbPagamento.SelectedItem + "\n";

                pago = Double.Parse(txtPago.Text);
                troco = pago - total;

                if (MessageBox.Show(dados + pedido + "Troco: " + troco.ToString("0.00"), "Deseja salvar o pedido?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtSalvos.Text += dados + "\n" + "Troco: " + troco.ToString("0.00") + "\n" + pedido + "\n";
                    foreach (Control limpar in this.Controls)
                    {
                        if (limpar is RadioButton)
                            if (((RadioButton)limpar).Checked)
                                ((RadioButton)limpar).Checked = false;
                        if (limpar is ComboBox)
                            if (((ComboBox)limpar).SelectedIndex > -1)
                                ((ComboBox)limpar).SelectedIndex = -1;
                        if (limpar is TextBox)
                        {
                            if(((TextBox)limpar).Text != txtSalvos.Text)
                                ((TextBox)limpar).Text = "";
                        }

                        total = 0;
                        pizza = 0;
                        refri = 0;
                        extras = 0;
                    }

                    foreach (Control limpar in grpSabores.Controls)
                    {
                        if (limpar is ComboBox)
                            if (((ComboBox)limpar).SelectedIndex > -1)
                                ((ComboBox)limpar).SelectedIndex = -1;
                        if (limpar is CheckBox)
                            if (((CheckBox)limpar).Checked)
                                ((CheckBox)limpar).Checked = false;
                    }

                    foreach (Control limpar in grpRefri.Controls)
                        if (limpar is ComboBox)
                            if (((ComboBox)limpar).SelectedIndex > -1)
                                ((ComboBox)limpar).SelectedIndex = -1;

                    foreach (Control limpar in grpOpcionais.Controls)
                    {
                        if (limpar is CheckBox)
                            if (((CheckBox)limpar).Checked)
                                ((CheckBox)limpar).Checked = false;
                        if (limpar is ComboBox)
                            if (((ComboBox)limpar).SelectedIndex > -1)
                                ((ComboBox)limpar).SelectedIndex = -1;
                        if (limpar is TextBox)
                            ((TextBox)limpar).Text = "";

                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente!");
            }
        }
    }
}
