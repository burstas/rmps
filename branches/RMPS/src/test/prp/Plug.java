/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * Plug.java
 *
 * Created on 2009-11-26, 13:10:57
 */

package test.prp;

/**
 *
 * @author yihaodian
 */
public class Plug extends javax.swing.JPanel {

    /** Creates new form Plug */
    public Plug() {
        initComponents();
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        pl_Info = new javax.swing.JPanel();
        lb_Soft = new javax.swing.JLabel();
        lb_Tree = new javax.swing.JLabel();
        lb_Menu = new javax.swing.JLabel();
        pl_Soft = new javax.swing.JPanel();

        pl_Info.setLayout(new java.awt.BorderLayout());

        lb_Soft.setText("jLabel1");
        pl_Info.add(lb_Soft, java.awt.BorderLayout.CENTER);

        lb_Tree.setText("jLabel2");
        pl_Info.add(lb_Tree, java.awt.BorderLayout.WEST);

        lb_Menu.setText("jLabel3");
        pl_Info.add(lb_Menu, java.awt.BorderLayout.EAST);

        pl_Soft.setBorder(javax.swing.BorderFactory.createEtchedBorder());

        javax.swing.GroupLayout pl_SoftLayout = new javax.swing.GroupLayout(pl_Soft);
        pl_Soft.setLayout(pl_SoftLayout);
        pl_SoftLayout.setHorizontalGroup(
            pl_SoftLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 176, Short.MAX_VALUE)
        );
        pl_SoftLayout.setVerticalGroup(
            pl_SoftLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 100, Short.MAX_VALUE)
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(pl_Info, javax.swing.GroupLayout.DEFAULT_SIZE, 200, Short.MAX_VALUE)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(pl_Soft, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(pl_Info, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(pl_Soft, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel lb_Menu;
    private javax.swing.JLabel lb_Soft;
    private javax.swing.JLabel lb_Tree;
    private javax.swing.JPanel pl_Info;
    private javax.swing.JPanel pl_Soft;
    // End of variables declaration//GEN-END:variables

}