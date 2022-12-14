<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="books">
    <html> 
        <body>
            <h2>book store</h2>
            <table border="1" >
                <xsl:for-each select="book">
                    <tr>
                        <td><xsl:value-of select="position()"/></td>
                        <td><xsl:value-of select="author"/></td>
                        <td><xsl:value-of select="title"/></td>
                        <td><xsl:value-of select="price"/></td>
                    </tr>
                </xsl:for-each>
            </table>
        </body>
    </html>
</xsl:template>
</xsl:stylesheet>