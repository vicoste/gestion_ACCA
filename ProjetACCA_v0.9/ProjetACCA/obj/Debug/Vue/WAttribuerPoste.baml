   M S B A M L   `   `   `  ����E  AProjetACCA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Projet_tut_ACCA.VueProjet_tut_ACCA.Vue  5   	   )    #Projet_tut_ACCA.Vue.WAttribuerPoste   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Projet_tut_ACCA.Vue     5   	     � Title$  Attribuer un poste à ��5   	   $	��300��6'   $	��300��64    � 
ResizeMode$ NoResize=�6@   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��33* �6   �� 5      $	��33* �6   �� 5      $	��33* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
textSearch��5      $��2��6&   $	��150��6;   $��50��6G    �� TextAlignment$
 Left=�6S   �� 5   
   -   5        $��2��5      $��	Recherche��68   $��50��6L   �� 5   
   -   5         ��Name$ 
cBoxPostes��5      $��1��6'   $��3��64    �� SelectedIndex$ 0��6H   $	��200��6Z   $��50��6f   � 5   
   $��2��6   $��3��6    5      �� 5      �� 5      .+�5!      �� -   5        $��Annuler��5!      $	��100��6<   $��50��6H   �� 5"      -   5        $��1��5"      $��Valider��6%   $	��100��6L   $��50��6X   5#      5$      5%      