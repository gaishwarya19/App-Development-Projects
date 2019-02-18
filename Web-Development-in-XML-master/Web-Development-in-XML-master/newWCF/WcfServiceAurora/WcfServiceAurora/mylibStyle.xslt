<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:template match="/">
 <html> 
<body>
  <h2>My Team Members and their favorites</h2>
  <table border="1">
    <tr bgcolor="#00e6e6">
      <th style="text-align:left">First Name</th>
      <th style="text-align:left">Last Name</th>
	  <th style="text-align:left">M Number</th>
      <th style="text-align:left">ShortCut</th>
    </tr>
    <xsl:for-each select="userdetails/users">
    <tr>
      <td><xsl:value-of select="firstname"/></td>
      <td><xsl:value-of select="lastname"/></td>
	    <td><xsl:value-of select="bearcatid"/></td>
      <td><xsl:value-of select="favoriteshortcut"/></td>
    </tr>
    </xsl:for-each>
  </table>
</body>
</html>
    </xsl:template>
</xsl:stylesheet>
