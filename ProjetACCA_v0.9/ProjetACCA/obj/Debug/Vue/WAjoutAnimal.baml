   M S B A M L   `   `   `  ����E  AProjetACCA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Projet_tut_ACCA.VueProjet_tut_ACCA.Vue  5   	   &     Projet_tut_ACCA.Vue.WAjoutAnimal   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Projet_tut_ACCA.Vue     5   	   $	��600��5   	   $	��400��6     � 
ResizeMode$  NoResize=�5	   	    � Title$ Entrer un Animal chassé��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $	��50* �6   �� 5      $	��20* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $
��Type��6   $��Center=�6,   $��Center=�6J   �� 5   
   $��1��6   $��Numéro Bague��6   $��Center=�64   $��Center=�6R   �� 5   
   $��2��6   $
��Sexe��6   $��Center=�6,   $��Center=�6J   �� 5   
   $��3��6   $
��Date��6   $��Center=�6,   $��Center=�6J   �� 5   
   $��4��6   $��Masse��6   $��Center=�6-   $��Center=�6J   �� 5    
   $��5��6   $��
Zone/Poste��6   $��Center=�62   $��Center=�6O   �� 5!   
   $��6��6   $��Observation��6   $��Center=�63   $	��Top=�6Q   �� 5#   
   -   5         ��Name$ button_valider��5#      $��1��6)   $��7��69   $��Valider��6F   $��Center=�6X   $��Center=�6u   $��74��6�   $��2��6�   �� 5$   
   -   5        $ button_annuler��5$      $��0��6)   $��7��69   $��Annuler��6F   $��Center=�6X   $��Center=�6u   $��74��6�   $��2��6�   6�   �� 5&   
   $��1��6   $��Center=�6%   .+�5'      �� -   5         ��Name$ comboBoxType��5'      $��Center=�6-   $��Center=�6J    �� SelectedItem$ Nouveau Type��6e   $��0,0,0,10q�6�   �� 5(      -   5         ��Name$ textBoxDefType��5(      .��6.   ��5)      �� 5*      .�5+      ��  �� Property � y�	 �� Value$	 Hidden=�6?   
 �� Triggers
 5,      �� 5-       �� Binding 5.   !   ��  �� ElementName$ comboBoxType�� �� Path$ SelectedValue� �� Value Nouveau Type6b   .a�5/   "   ��  � y�$	 Visible=�6G   50      52      .��53   !   54      55      �� 56   
   -   5        $ boxBague��56      $��1��6$   $��1��61   $��20��6A   $	��150��6M   .��6Y   ��57      �� 58      
 59      �� 5:       5;      �� $ comboBoxType��$ SelectedValue� Nouveau Type6_   .a�5<      ��  � ��$	 -1��6=   �� 5=       � |�	 .  6B   5>      5@      .��5A      5B      � 5C   
   $��1��6   $��2��6$   $��Center=�61   $��Center=�6L   .+�5D      	� -   5         	�Name$ rbSexeM��5D      $��Mâle��6+   $
��Left=�6:    d� 	IsChecked$
 TrueY�6U   	� 5E      -   5        $ rbSexeF��5E      $��Femelle��6+   $��20,0,0,0q�6=   $��Right=�6O   5F      (  "System.Windows.Controls.DatePicker  5G   
   -   5          Name$ datePick��5G      $��3��6(   $��1��65   $��Center=�6E   $��Center=�6`      Text$ Selectioner Une date��6}   �� 5H   
   -	   5        $ textBoxMasse��5H      $��4��6(   $��1��65   $��Center=�6E    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $��Center=�6~   $	��120��6�   �� 5J   
   -
   5        $ comboBoxZone��5J      $��5��6)   $��1��66   $	��Top=�6F    �� SelectedIndex$ 0��6^   $	��150��6p   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6|   �� 5K   
   -   5        $ comboBoxPoste��5K      $��5��6*   $��1��67   $��Bottom=�6G   $ 0��6b   $	��150��6t   ��6�   �� $ comboBoxZone��$ SelectedItem.ListPoste��� 5M   
   -   5        $ 
textBoxObs��5M      $��6��6&   $��2��63   $��Center=�6G   $
 Wrap=�6d   $�� ��6x   $��Center=�6�   $	��350��6�   $	��100��6�   5N      5O      