   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   &     WpfApplication1.FiltracijaProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  FiltracijaProzor��5   	   $	��430��6"   $	��750��6/   .��5	      � $��0,0,0,0q�6   .+�5   
   �� -   5        $��idFilter��5   M   $��24��6   $
��Left=�6   $��
102,27,0,0q�69   $	��Top=�6]   $��80��6u   �� 5   
   -   5        $��	imeFilter��5   M   $��24��6   $
��Left=�6   $��
102,57,0,0q�69   $	��Top=�6^   $��80��6v   �� 5   
   -   5        $��cbFrekvencija��5   N   $��24��6   $
��Left=�6   $��
102,87,0,0q�6:   $	��Top=�6c   $��80��6{   .@�5      �� $�� ��6   �� 5      $��Redak��6   �� 5      $��Čest��6   �� 5      $��Univerzalan��6   5      �� 5   
   -   5        $��cbMera��5   O   $��24��6   $
��Left=�6   $��102,117,0,0q�6:   $	��Top=�6]   $��80��6u   .@�5      �� $�� ��6   �� 5      -   5        $��merica��5   ,   $��Merica��6   6,   �� 5      -   5        $��barel��5   +   $��Barel��6   6+   �� 5      -   5        $
��tona��5   *   $
��Tona��6   6*   �� 5      -   5        $��kilogram��5   .   $��Kilogram��6   6.   5      � 5   
   -	   5        $��
wrapPanel1��5   O   $��28��6   $
��Left=�6    $��
350,28,0,0q�6;   $	��Top=�6a   $	��136��6y   .+�5      	� -
   5         	�Name$ 	rbVazanDa��5   3   $��Da��6   $��16��6'   $	��Top=�6F   $��5,2,0,0q�6^   	� 5      -   5        $ 	rbVazanNe��5   '   $��Ne��6   $
��Left=�6:   $��5,2,0,0q�6V   $	��Top=�6g   $��22��6   5      � 5   
   -   5        $��
wrapPanel2��5   O   $��22��6   $
��Left=�6    $��
350,64,0,0q�6;   $	��Top=�6a   $	��116��6y   .+�5       	� -   5        $��rbObnovljivDa��5    3   $��Da��6   $��16��6'   $��5,2,0,0q�6H   	� 5!      -   5        $��rbObnovljivNe��5!   3   $��Ne��6   $��16��6'   $��10,2,0,0q�6H   5"      � 5#   
   -   5        $��
wrapPanel3��5#   O   $��20��6   $
��Left=�6    $��
350,96,0,0q�6;   $	��Top=�6a   $	��116��6y   .+�5$      	� -   5        $��rbEksploatacijaDa��5$   3   $��Da��6   $��16��6'   $��5,2,0,0q�6L   	� 5%      -   5        $��rbEksploatacijaNe��5%   3   $��Ne��6   $��16��6'   $��10,2,0,0q�6L   5&      �� 5'   
   -   5        $��filtrirajButton��5'   a   $��	Filtriraj��6   $��28��6%   $
��Left=�61   $��202,165,0,0q�6L   $	��Top=�6x   $��80��6�    � ToolTip 5(      �� 5)       �� Orientation$ 
Horizontal=�6   .+�5*      �� $��5q�6    $
��Wrap=�6+   $	��100��6?   hf[Filtriranje resursa] Izaberite željene paramete i pritisnite ovo dugme za filtriranje liste resursa.5-      5.      50      �� 51   
   -   5        $��ponistiButton��51   c   $��Poništi sve��6   $��28��6'   $
��Left=�63   $��338,165,0,0q�6N   $	��Top=�6x   $��74��6�    52      �� 53      $ 
Horizontal=�6   .+�54      �� $��5q�6    $
��Wrap=�6+   $	��200��6?   nl[Resetovanje parametara za filtriranje] Pritisnite na ovo dugme da bi poništili kriterijume za filtriranje.57      58      5:      &   System.Windows.Controls.DataGrid  5;   
   $
��Left=�6   $	��155��6.   $��
10,219,0,0q�6;      CanUserAddRows .     AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   $	��Top=�6�   $	��708��6�   ��6�   ��  �� Path$ listaResursa�   Columns 5<      4  .System.Windows.Controls.DataGridTemplateColumn  5=      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Slika��6)   
   
IsReadOnly
 .     CellTemplate 5>      �� 5?      .R�5@      �� $��30��6$   $��60��6M   ��60   �� *	imagePath+6M   5A      5C      0  *System.Windows.Controls.DataGridTextColumn  5E      $	 ID��6<   
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6H     5F      $	 Naziv��6=   
 .  6%   �� *ime+6L     5G      $
	 Opis��6>   
 .  6%   �� *opis+6L     5I      $		 Tip��6=   
 .  6%   �� *tip+6J     5J      $	 Pojavljivanje��6G   
 .  6%   �� *frekvencijaCB+6^     5K      $	 Važan��6H   
 .  6%   �� *strateskiVazan+6W     5L      $	 	Obnovljiv��6C   
 .  6%   �� *	obnovljiv+6V     5N      $	 Eksploatacija��6G   
 .  6%   �� *eksploatacija+6^     5O      $
	 Mera��6>   
 .  6%   �� *mera+6L     5P      $
	 Cena��6>   
 .  6%   �� *cena+6L     5Q      $	 Datum��6I   
 .  6%   �� *datumOtkrivanja+6X   5T      �� 5U   
   -   5        $��cbTip��5U      $
��Left=�6!   $��102,146,0,0q�6<   $	��Top=�6Q   $��80��6i   �� 5V   
   $
��Ime:��6   $
��Left=�6   $��	36,25,0,0q�6:   $	��Top=�6M   �� 5W   
   $	��Id:��6   $
��Left=�6   $��	36,59,0,0q�69   $	��Top=�6L   �� 5X   
   $��Frekvencija:��6   $
��Left=�6'   $��	10,87,0,0q�6B   $	��Top=�6U   �� 5Y   
   $��Mera:��6   $
��Left=�6    $��
36,117,0,0q�6;   $	��Top=�6O   �� 5Z   
   $
��Tip:��6   $
��Left=�6   $��
36,146,0,0q�6:   $	��Top=�6N   �� 5[   
   $��Strateški važan:��6   $
��Left=�6+   $��
207,23,0,0q�6F   $	��Top=�6Z   �� 5\   
   $��
Obnovljiv:��6   $
��Left=�6%   $��
207,59,0,0q�6@   $	��Top=�6T    J� RenderTransformOrigin$ 0.092,-0.058&�6l   �� 5]   
   $��Moguća eksploatacija:��6   $
��Left=�60   $��
207,91,0,0q�6K   $	��Top=�6_   5_      5`      