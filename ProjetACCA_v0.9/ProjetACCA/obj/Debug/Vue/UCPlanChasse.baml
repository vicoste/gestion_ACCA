   M S B A M L   `   `   `  ����E  AProjetACCA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Projet_tut_ACCA.VueProjet_tut_ACCA.Vue  5      &     Projet_tut_ACCA.Vue.UCPlanChasse   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Projet_tut_ACCA.Vue     5        � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Dictionar_style.xaml?�5      5      %    5      .��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��70* �6   �� 5      $	��20* �6   .+�5   
   � $��Center=�6   .+�5      �� $��Rechercher par une date��6   $��Center=�67   �� 5      -   5         ��Name$ dateRecherche��5      $	��105��6-   $��Center=�69   $
��20,2q�6T   .��6b    � ToolTip$ 
jj/mm/aaaa��5   >   .��5      �� 5      -   5        $	��0,2q�5   -   $��25��6:   $��25��6E   
����������#199D33$
��Left=�6z   $��Center=�6�   $ 
Rechercher��5    <   .��5!      �� $��/Image/Magnifier.png��6   5"      �� 5#      -   5        $	��0,2q�5#   )   $��25��66   $��25��6A   
����������#199D33$
��Left=�6y   $��Center=�6�   $ Réinitialiser��5$   ?   .��5%      �� $��/Image/reset.png��6   5&      5'      &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ gridAnimaux��5)         AutoGenerateColumns .  $��1��6�      
IsReadOnly . ��6(   �� 	 �� Path$	 
LesAnimaux�
 �� UpdateSourceTrigger$
 PropertyChanged=�   Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$
 Type��6%      SortDirection$ 	AscendingX�6q      CanUserReorder .     MinWidth$	 100Q�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Type+$
 PropertyChanged=�6�     5,      $ 	N° Bague��6%    67   �� *
NumBague+$
 PropertyChanged=�  5-      $
 Date��6%    63   �� *DatePrelevement+$
 PropertyChanged=� �� StringFormat$ {0:dd/MM/yyyy}��  5.      $
 Sexe��6%    63   �� *Sexe+$
 PropertyChanged=�  5/      $ Poids��6%    64   �� *Masse+$
 PropertyChanged=�  50      $ Observation��6%   $	 300Q�6    6:   �� *Observation+$
 PropertyChanged=�6   4  .System.Windows.Controls.DataGridTemplateColumn  51      $ 
Operations��6)      CellTemplate 52      �� 53      .R�54      � .+�55   "   �� -   5        $��Suppr.��55   )   $��70��6N   ��56   &   �� 57   *    �� Triggers 58   .   �� 59   2    �� Binding 6>   �� *Sexe+ �� Value N6W   .a�5:   6   ��  �� Property � y� �� Value$ Hidden=�6Z   5;   3   5=   +   5?   #   5@      5A      5C      5E      � 5G   
   $��2��6   $��Center=�6!   .+�5H      �� -   5           boutonConnexion#��[  5H      $��Ajouter��6>   $��98��6e   $��	10,0,10,0q�6q   �� 5I      -   5        #��[  5I      $��Gestionnaire Bague��6>   $��59��6q   $	��193��6}   5J      5K      5L      