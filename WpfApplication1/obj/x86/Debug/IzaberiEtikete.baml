   M S B A M L   `   `   `  ����  WpfApplication1$    WpfApplication1.IzaberiEtikete   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  IzaberiEtikete��5   	   $	��272��6    $	��376��6-   
�������.��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��etiketeDataGrid��5   j      AutoGenerateColumns .  $	��167��6/   $
��Left=�6<   $��	12,13,0,0q�6W      CanUserAddRows .  $	��Top=�6�   $	��325��6�   ��6�   ��  �� Path$ ListaEtiketaWind�   Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ CB��6x   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
selected+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6x   4  .System.Windows.Controls.DataGridTemplateColumn  5	      $
 Boja��6)   	   
IsReadOnly	 .  
   CellTemplate
 5
      �� 5      .R�5      �� $��30��6(   $��60��6J   ��64   �� *boja+6J   5      5      0  *System.Windows.Controls.DataGridTextColumn  5      $ ID��6<   	 .  6%   �� *id+6H     5      $
 Opis��6>   	 .  6%   �� *opis+6L   5      �� 5   
   -   5        $��izaberiButton��5   g   $��Izaberi etikete��6   $��23��6+   $
��Left=�67   $��132,198,0,0q�6R   $	��Top=�6|   $��88��6�   6�   5      5      