<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staging</title>
    <link href="../../Styles/base.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Treemap.css" rel="stylesheet" type="text/css" />
    <script src="../../Skripts/jit.js" type="text/javascript"></script>
    <script src="../../Skripts/WordsTree.Sample.js" type="text/javascript"></script>
</head>
<body  onload="init();">
     <div id="container">
        <div id="left-container">
            <div class="text">
                <h4>
                    Animated Squarified, SliceAndDice and Strip TreeMaps
                </h4>
                In this example a static JSON tree is loaded into a Squarified Treemap.<br />
                <br />
                <b>Left click</b> to set a node as root for the visualization.<br />
                <br />
                <b>Right click</b> to set the parent node as root for the visualization.<br />
                <br />
                You can <b>choose a different tiling algorithm</b> below:
            </div>
            <div id="id-list">
                <table>
                    <tr>
                        <td>
                            <label for="r-sq">
                                Squarified
                            </label>
                        </td>
                        <td>
                            <input type="radio" id="r-sq" name="layout" checked="checked" value="left" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="r-st">
                                Strip
                            </label>
                        </td>
                        <td>
                            <input type="radio" id="r-st" name="layout" value="top" />
                        </td>
                        <tr>
                            <td>
                                <label for="r-sd">
                                    SliceAndDice
                                </label>
                            </td>
                            <td>
                                <input type="radio" id="r-sd" name="layout" value="bottom" />
                            </td>
                        </tr>
                </table>
            </div>
            <a id="back" href="#" class="theme button white">Go to Parent</a>
            <div style="text-align: center;">
                <a href="example1.js">See the Example Code</a></div>
        </div>
        <div id="center-container">
            <div id="infovis">
            </div>
        </div>
        <div id="right-container">
            <div id="inner-details">
            </div>
        </div>
        <div id="log">
        </div>
    </div>
</body>
</html>