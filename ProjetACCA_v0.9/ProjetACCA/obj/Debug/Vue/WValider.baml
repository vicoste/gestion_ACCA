   M S B A M L   `   `   `  ����E  AProjetACCA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Projet_tut_ACCA.VueProjet_tut_ACCA.Vue  5   	   "    Projet_tut_ACCA.Vue.WValider   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Projet_tut_ACCA.Vue     5   	     � Title$  Valider votre choix ?��5   	   $	��150��6'   $	��300��64    � 
ResizeMode$ NoResize=�6@   .��5	      �  � 	Resources 5
   
    �� 
TargetType �� Property �� Value��%R   '��       �� 5      " ��6   .�5      ��  � ��$ 12q�6+   5      5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	LightBlue��6   	 � Offset$	 0Q�61   � 5      $ 	AliceBlue��6   $	 0.497Q�61   5      
 � ColumnDefinitions
 5   
   �� 5      $	��50* �6   �� 5      $	��50* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��2��6   $(��"Êtes-vous sur de vouloir partir ?��6)   $��Center=�6R   $��Center=�6o   $
��Bold"�6�   $��16(�6�   $
��0,10q�6�   �� 5   
   -   5         ��Name$	 oui��5      $��1��6   $	��Oui��6+   
��� � �6L   �� 5    
   -   5        $	 non��5       $��1��6   $��1��6+   $	��Non��6;   
���  ��6Z   5!      5"      