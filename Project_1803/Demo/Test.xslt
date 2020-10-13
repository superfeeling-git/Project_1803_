<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:template match="/">
		<html>
			<head>
				<title>DEMO</title>
				<style type="text/css">
					body
					{
						background-color: #ffff00;
						font-size: 10px;
					}
					td
					{
						font-size :12px;
					}
				</style>
			</head>
			<body>
				<table width="700" align="center" bgcolor="#0000ff" border="0" cellpadding="5" cellspacing="1">
					<tbody>
						<xsl:for-each select="DEMO/EMAIL">
							<tr>
								<th bgcolor="#ffffff" colspan="2" align="center">
									<h2>
										<xsl:value-of select="TO/@title"/>
									</h2>
								</th>
							</tr>
							<tr>
								<td bgcolor="#ffffff" width="100px" align="center">
									<b>TO</b>
								</td>
								<td bgcolor="#ffffff" width="600px" align="left">
									<xsl:value-of select="TO"/>
								</td>
							</tr>
							<tr>
								<td bgcolor="#ffffff" align="center">
									<b>FROM</b>
								</td>
								<td bgcolor="#ffffff" align="left">
									<xsl:value-of select="FROM"/>
								</td>
							</tr>
							<tr>
								<td bgcolor="#ffffff" align="center">
									<b>CC</b>
								</td>
								<td bgcolor="#ffffff" align="left">
									<xsl:for-each select="CC">
										<xsl:value-of select="."/> 、
									</xsl:for-each>
								</td>
							</tr>
							<tr>
								<td bgcolor="#ffffff" align="center">
									<b>SUBJECT</b>
								</td>
								<td bgcolor="#ffffff" align="left">
									<xsl:value-of select="SUBJECT"/>
								</td>
							</tr>
							<tr>
								<td bgcolor="#ffffff" align="center">
									<b>BODY</b>
								</td>
								<td bgcolor="#ffffff" align="left">
									<pre>
										<xsl:value-of select="BODY"/>
									</pre>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
