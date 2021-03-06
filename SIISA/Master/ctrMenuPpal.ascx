﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrMenuPpal.ascx.cs" Inherits="SIISAConc.Master.ctrMenuPpal" %>
<style>
    #cssmenu ul,
    #cssmenu li,
    #cssmenu span,
    #cssmenu a {
        margin: 0;
        padding: 0;
        position: relative;
    }

    #cssmenu {
        height: 49px;
        -moz-border-radius: 5px 5px 0 0;
        -webkit-border-radius: 5px 5px 0 0;
        border-radius: 5px 5px 0 0;
        background: #141414;
        background: -moz-linear-gradient(top, #32323a 0%, #141414 100%);
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #32323a), color-stop(100%, #141414));
        background: -webkit-linear-gradient(top, #32323a 0%, #141414 100%);
        background: -o-linear-gradient(top, #32323a 0%, #141414 100%);
        background: -ms-linear-gradient(top, #32323a 0%, #141414 100%);
        background: linear-gradient(to bottom, #32323a 0%, #141414 100%);
        filter: progid:DXImageTransform.Microsoft.Gradient(StartColorStr='#32323a', EndColorStr='#141414', GradientType=0);
        border-bottom: 2px solid #0fa1e0;
    }

        #cssmenu:after,
        #cssmenu ul:after {
            content: '';
            display: block;
            clear: both;
        }

        #cssmenu a {
            background: #141414;
            background: -moz-linear-gradient(top, #32323a 0%, #141414 100%);
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #32323a), color-stop(100%, #141414));
            background: -webkit-linear-gradient(top, #32323a 0%, #141414 100%);
            background: -o-linear-gradient(top, #32323a 0%, #141414 100%);
            background: -ms-linear-gradient(top, #32323a 0%, #141414 100%);
            background: linear-gradient(to bottom, #32323a 0%, #141414 100%);
            filter: progid:DXImageTransform.Microsoft.Gradient(StartColorStr='#32323a', EndColorStr='#141414', GradientType=0);
            color: #ffffff;
            display: inline-block;
            font-family: Helvetica, Arial, Verdana, sans-serif;
            font-size: 12px;
            line-height: 49px;
            padding: 0 20px;
            text-decoration: none;
        }

        #cssmenu ul {
            list-style: none;
        }

        #cssmenu > ul {
            float: left;
        }

            #cssmenu > ul > li {
                float: left;
            }

                #cssmenu > ul > li:hover:after {
                    content: '';
                    display: block;
                    width: 0;
                    height: 0;
                    position: absolute;
                    left: 50%;
                    bottom: 0;
                    border-left: 10px solid transparent;
                    border-right: 10px solid transparent;
                    border-bottom: 10px solid #0fa1e0;
                    margin-left: -10px;
                }

                #cssmenu > ul > li:first-child a {
                    -moz-border-radius: 5px 0 0 0;
                    -webkit-border-radius: 5px 0 0 0;
                    border-radius: 5px 0 0 0;
                }

                #cssmenu > ul > li:last-child a {
                    -moz-border-radius: 0 5px 0 0;
                    -webkit-border-radius: 0 5px 0 0;
                    border-radius: 0 5px 0 0;
                }

                #cssmenu > ul > li.active a {
                    -moz-box-shadow: inset 0 0 3px #000000;
                    -webkit-box-shadow: inset 0 0 3px #000000;
                    box-shadow: inset 0 0 3px #000000;
                    background: #070707;
                    background: -moz-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #26262c), color-stop(100%, #070707));
                    background: -webkit-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: -o-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: -ms-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: linear-gradient(to bottom, #26262c 0%, #070707 100%);
                    filter: progid:DXImageTransform.Microsoft.Gradient(StartColorStr='#26262c', EndColorStr='#070707', GradientType=0);
                }

                #cssmenu > ul > li:hover > a {
                    background: #070707;
                    background: -moz-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: -webkit-gradient(linear, left top, left bottom, color-stop(0%, #26262c), color-stop(100%, #070707));
                    background: -webkit-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: -o-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: -ms-linear-gradient(top, #26262c 0%, #070707 100%);
                    background: linear-gradient(to bottom, #26262c 0%, #070707 100%);
                    filter: progid:DXImageTransform.Microsoft.Gradient(StartColorStr='#26262c', EndColorStr='#070707', GradientType=0);
                    -moz-box-shadow: inset 0 0 3px #000000;
                    -webkit-box-shadow: inset 0 0 3px #000000;
                    box-shadow: inset 0 0 3px #000000;
                }

        #cssmenu .has-sub {
            z-index: 1;
        }

            #cssmenu .has-sub:hover > ul {
                display: block;
            }

            #cssmenu .has-sub ul {
                display: none;
                position: absolute;
                width: 200px;
                top: 100%;
                left: 0;
            }

                #cssmenu .has-sub ul li {
                    *margin-bottom: -1px;
                }

                    #cssmenu .has-sub ul li a {
                        background: #0fa1e0;
                        border-bottom: 1px dotted #6fc7ec;
                        filter: none;
                        font-size: 11px;
                        display: block;
                        line-height: 120%;
                        padding: 10px;
                    }

                    #cssmenu .has-sub ul li:hover a {
                        background: #0c7fb0;
                    }

            #cssmenu .has-sub .has-sub:hover > ul {
                display: block;
            }

            #cssmenu .has-sub .has-sub ul {
                display: none;
                position: absolute;
                left: 100%;
                top: 0;
            }

                #cssmenu .has-sub .has-sub ul li a {
                    background: #0c7fb0;
                    border-bottom: 1px dotted #6db2d0;
                }

                    #cssmenu .has-sub .has-sub ul li a:hover {
                        background: #095c80;
                    }
</style>
<div>


    <asp:Repeater ID="FirstLevelMenuRepeater" runat="server" OnItemDataBound="FirstLevelMenuRepeater_ItemDataBound">
        <HeaderTemplate>
            <div id="cssmenu">
                <ul id="menuroot">
        </HeaderTemplate>
        <ItemTemplate>
            <li class="has-sub">
                <asp:HyperLink ID="FirstLevelMenu" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>' Text='<%# DataBinder.Eval(Container.DataItem, "menuObjeto") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "descripObjeto") %>'>
                </asp:HyperLink>
                <asp:Label ID="lblIdObjeto" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "idObjeto") %>'></asp:Label>
                <asp:Repeater ID="SecondLevelMenuRepeater" runat="server">
                    <HeaderTemplate>
                        <ul id="menusecondlevel">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="SecondLevelMenu" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "menuObjeto") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "descripObjeto") %>'>
                            </asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</div>
