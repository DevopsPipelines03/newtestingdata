param location string = 'eastus'
param clusterName string = 'deploy-aks-cluster'
param vmSize string = 'standard_d2s_v3'

resource aks 'Microsoft.ContainerService/managedClusters@2021-10-01' = {
  name: clusterName
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    dnsPrefix: clusterName
    enableRBAC: true
    agentPoolProfiles: [
      {
        name: 'agentpool'
        count: 1
        vmSize: vmSize
        mode: 'System'
        maxCount: 2
        minCount: 1
        enableAutoScaling: true
      }
    ]
  }
}
