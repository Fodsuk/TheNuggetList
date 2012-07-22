<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="TheNuggetList.WebUI.Azure" generation="1" functional="0" release="0" Id="0b2d51ca-b850-4ae7-87aa-4f124b214749" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="TheNuggetList.WebUI.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="TheNuggetList.WebUI:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/LB:TheNuggetList.WebUI:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/LB:TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapCertificate|TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="TheNuggetList.WebUIInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/MapTheNuggetList.WebUIInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:TheNuggetList.WebUI:Endpoint1">
          <toPorts>
            <inPortMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapTheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapTheNuggetList.WebUIInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUIInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="TheNuggetList.WebUI" generation="1" functional="0" release="0" software="C:\Users\Fods\Documents\Visual Studio 2010\Projects\thenuggetlist\TheNuggetList.WebUI.Azure\csx\Debug\roles\TheNuggetList.WebUI" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/SW:TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;TheNuggetList.WebUI&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;TheNuggetList.WebUI&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUIInstances" />
            <sCSPolicyFaultDomainMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUIFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="TheNuggetList.WebUIFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="TheNuggetList.WebUIInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="62d614f9-87b2-481a-af17-a6deacf08aa1" ref="Microsoft.RedDog.Contract\ServiceContract\TheNuggetList.WebUI.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="452151dc-9730-4b3e-8f65-926484e428bc" ref="Microsoft.RedDog.Contract\Interface\TheNuggetList.WebUI:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="06e3df0f-e409-4895-a8ff-8ce75f2959ce" ref="Microsoft.RedDog.Contract\Interface\TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/TheNuggetList.WebUI.Azure/TheNuggetList.WebUI.AzureGroup/TheNuggetList.WebUI:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>