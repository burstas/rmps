/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * Prps.java
 *
 * Created on 2009-11-26, 10:28:46
 */

package test.prp;

/**
 * 
 * @author Amon
 */
public class Prps extends javax.swing.JFrame
{

    /** Creates new form Prps */
    public Prps()
    {
        initComponents();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed"
    // desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents()
    {

        pl_HeadPane = new javax.swing.JPanel();
        pl_FootPane = new javax.swing.JPanel();
        tp_BodyPane = new javax.swing.JTabbedPane();
        jButton1 = new javax.swing.JButton();
        mb_RmpsMenu = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMenu2 = new javax.swing.JMenu();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        javax.swing.GroupLayout pl_HeadPaneLayout = new javax.swing.GroupLayout(pl_HeadPane);
        pl_HeadPane.setLayout(pl_HeadPaneLayout);
        pl_HeadPaneLayout.setHorizontalGroup(pl_HeadPaneLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 230, Short.MAX_VALUE));
        pl_HeadPaneLayout.setVerticalGroup(pl_HeadPaneLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 100, Short.MAX_VALUE));

        javax.swing.GroupLayout pl_FootPaneLayout = new javax.swing.GroupLayout(pl_FootPane);
        pl_FootPane.setLayout(pl_FootPaneLayout);
        pl_FootPaneLayout.setHorizontalGroup(pl_FootPaneLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 230, Short.MAX_VALUE));
        pl_FootPaneLayout.setVerticalGroup(pl_FootPaneLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 100, Short.MAX_VALUE));

        tp_BodyPane.setTabPlacement(javax.swing.JTabbedPane.LEFT);

        jButton1.setText("jButton1");
        tp_BodyPane.addTab("tab1", jButton1);

        jMenu1.setText("File");
        mb_RmpsMenu.add(jMenu1);

        jMenu2.setText("Edit");
        mb_RmpsMenu.add(jMenu2);

        setJMenuBar(mb_RmpsMenu);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(pl_HeadPane, javax.swing.GroupLayout.DEFAULT_SIZE,
                javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(pl_FootPane, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(tp_BodyPane, javax.swing.GroupLayout.DEFAULT_SIZE, 230, Short.MAX_VALUE));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addComponent(pl_HeadPane, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(tp_BodyPane, javax.swing.GroupLayout.DEFAULT_SIZE, 167, Short.MAX_VALUE).addPreferredGap(
                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pl_FootPane, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE,
                                javax.swing.GroupLayout.PREFERRED_SIZE)));

        pack();
    }// </editor-fold>//GEN-END:initComponents

    /**
     * @param args
     *            the command line arguments
     */
    public static void main(String args[])
    {
        java.awt.EventQueue.invokeLater(new Runnable()
        {
            public void run()
            {
                new Prps().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu2;
    private javax.swing.JMenuBar mb_RmpsMenu;
    private javax.swing.JPanel pl_FootPane;
    private javax.swing.JPanel pl_HeadPane;
    private javax.swing.JTabbedPane tp_BodyPane;
    // End of variables declaration//GEN-END:variables

}