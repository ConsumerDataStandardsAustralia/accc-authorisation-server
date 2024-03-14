import { useRecoilValue } from "recoil";
import { ClusterModel, CustomerModel } from "../models/DataModels";
import settings from "../settings";
import { CommonState } from "../state/Common.state";
import { ACCESS_DENIED_ERROR_CODE, ConsentState } from "../state/Consent.state";

export function useData() {
    const commonState = useRecoilValue(CommonState);
    const consentState = useRecoilValue(ConsentState);

    const getCustomerByLoginId = async (loginId: string): Promise<CustomerModel | null> => {
        let customerDataUrl: string = "";
        // depending on data holder get login info 
        if (commonState?.dataHolder?.BrandName == ""){
            customerDataUrl = settings.DATA_FILE_NAME;
        }else {
            customerDataUrl = settings.DATA_FILE_NAME;
        }
        let url = getFullUrl(customerDataUrl) + `?loginId=${loginId}`;
        const data = await fetch(url)
            .then((r) => r.json());
        const customers = data.Customers
            .filter((c: any) => c.LoginId === loginId) as CustomerModel[];

        return customers.length > 0 ? customers[0] : null;
    }

    const getAllClusters = async (): Promise<ClusterModel[] | null> => {
        const data = await fetch(getFullUrl(settings.CLUSTER_DATA_FILE_NAME))
            .then((r) => r.json());

        return data.Clusters as ClusterModel[];
    }

    const getFullUrl = (dataFileUrl: string | undefined) => {
        var dataUrl = dataFileUrl;
        if (dataUrl?.startsWith('http')) {
            return dataUrl;
        }
        return `${settings.PUBLIC_URL}/${dataUrl}`;
    }

    const submitConsentRequest = () => {
        var queryData = {
            ...commonState?.inputParams?.authorize_request,
            subject_id: consentState.subjectId,
            account_ids: consentState.accountIds?.join(','),
        } as any;
        
        if(consentState.errorCode){
            queryData.error_code = consentState.errorCode ?? "";
        }

        // Redirect back to the auth server
        window.location.replace(constructCallbackUrl(queryData));
    }

    const constructCallbackUrl = (queryData:any) => {
        var queryString = Object.entries(queryData).map(([key, value]) => `${key}=${value}`).join('&');
        return `${commonState.inputParams?.return_url}?${queryString}`;
    }

    const submitCancelConsentRequest = () => {
        var queryData = {
            ...commonState?.inputParams?.authorize_request,
            subject_id: consentState.subjectId,
            account_ids: consentState.accountIds?.join(','),
            error_code: ACCESS_DENIED_ERROR_CODE,
        };

        // Redirect back to the auth server
        window.location.replace(constructCallbackUrl(queryData));
    }

    return {
        getCustomerByLoginId,
        getAllClusters,
        submitConsentRequest,
        submitCancelConsentRequest
    };
};