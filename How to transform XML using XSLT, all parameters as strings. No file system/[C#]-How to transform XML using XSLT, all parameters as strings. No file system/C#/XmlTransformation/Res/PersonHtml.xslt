<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" indent="yes" omit-xml-declaration="yes" />
<xsl:template match="/">
		<html>
			<body>
				<div>
					<xsl:apply-templates/>
				</div>
			</body>
		</html>
</xsl:template>
<xsl:template match="Person">
		Name: <b><xsl:value-of select="Name" /></b>
		<br/>
		Age: <b><xsl:value-of select="Age"/></b>
</xsl:template>
</xsl:stylesheet>